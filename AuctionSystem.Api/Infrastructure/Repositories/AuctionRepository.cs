using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Domain.Enums;
using AuctionSystem.Api.Dtos.Auctions;
using Microsoft.EntityFrameworkCore;

namespace AuctionSystem.Api.Infrastructure.Repositories;

public class AuctionRepository : IAuctionRepository
{
    private readonly AuctionDbContext _db;
    public AuctionRepository(AuctionDbContext db)
    {
        _db = db;
    }

    public Task<Auction?> GetByIdAsync(int id)
    {
        return _db.Auctions.FindAsync(id).AsTask();
    }

    public async Task<PagedResult<Auction>> GetAllAsync(AuctionQueryParameters query)
    {
        var auctions = _db.Auctions.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Category))
        {
            auctions = auctions.Where(a => a.Category == query.Category);
        }

        if (query.Status.HasValue)
        {
            auctions = auctions.Where(a => a.Status == query.Status.Value);
        }

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            var s = query.Search.ToLower();
            auctions = auctions.Where(a =>
                a.Title.ToLower().Contains(s) ||
                a.Description.ToLower().Contains(s));
        }

        auctions = query.SortBy?.ToLower() switch
        {
            "title" => query.Desc ? auctions.OrderByDescending(a => a.Title) : auctions.OrderBy(a => a.Title),
            "startdate" => query.Desc ? auctions.OrderByDescending(a => a.StartDate) : auctions.OrderBy(a => a.StartDate),
            "enddate" => query.Desc ? auctions.OrderByDescending(a => a.EndDate) : auctions.OrderBy(a => a.EndDate),
            "currentprice" => query.Desc ? auctions.OrderByDescending(a => a.CurrentPrice) : auctions.OrderBy(a => a.CurrentPrice),
            _ => auctions.OrderBy(a => a.Id)
        };

        var total = await auctions.CountAsync();
        var items = await auctions.Skip((query.Page - 1) * query.PageSize)
                                  .Take(query.PageSize)
                                  .ToListAsync();

        return new PagedResult<Auction>(
            items,
            query.Page,
            query.PageSize,
            total
        );
    }

    public Task AddAsync(Auction auction)
    {
        return _db.Auctions.AddAsync(auction).AsTask();
    }

    public Task UpdateAsync(Auction auction)
    { 
        _db.Auctions.Update(auction);

        return Task.CompletedTask; 
    }

    public async Task UpdateStatusesAsync()
    {
        var now = DateTime.UtcNow;

        var auctions = await _db.Auctions.ToListAsync();

        foreach (var a in auctions)
        {
            if (now < a.StartDate)
            {
                a.Status = AuctionStatus.Draft;
            }
            else if (now >= a.StartDate && now < a.EndDate)
            {
                a.Status = AuctionStatus.Active;
            }
            else
            {
                a.Status = AuctionStatus.Finished;
            }
        }
    }

    public Task DeleteAsync(Auction auction)
    {
        _db.Auctions.Remove(auction);

        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        return _db.SaveChangesAsync();
    }
}