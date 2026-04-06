using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Dtos.Bids;
using Microsoft.EntityFrameworkCore;

namespace AuctionSystem.Api.Infrastructure.Repositories;

public class BidRepository : IBidRepository
{
    private readonly AuctionDbContext _db;
    public BidRepository(AuctionDbContext db)
    {
        _db = db;
    }

    public async Task<PagedResult<Bid>> GetBidsForAuctionAsync(int auctionId, BidQueryParameters query)
    {
        var bids = _db.Bids
            .Where(b => b.AuctionId == auctionId)
            .AsQueryable();

        bids = query.SortBy?.ToLower() switch
        {
            "amount" => query.Desc
                ? bids.OrderByDescending(b => b.Amount)
                : bids.OrderBy(b => b.Amount),

            "placedat" => query.Desc
                ? bids.OrderByDescending(b => b.PlacedAt)
                : bids.OrderBy(b => b.PlacedAt),

            "userid" => query.Desc
                ? bids.OrderByDescending(b => b.UserId)
                : bids.OrderBy(b => b.UserId),

            _ => bids.OrderByDescending(b => b.PlacedAt)
        };

        var total = await bids.CountAsync();
        var items = await bids.Skip((query.Page - 1) * query.PageSize)
                              .Take(query.PageSize)
                              .ToListAsync();

        return new PagedResult<Bid>(items, query.Page, query.PageSize, total);
    }

    public Task AddAsync(Bid bid)
    {
        return _db.Bids.AddAsync(bid).AsTask();
    }

    public Task SaveChangesAsync()
    {
        return _db.SaveChangesAsync();
    }
}