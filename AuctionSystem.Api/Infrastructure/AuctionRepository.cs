using AuctionSystem.Api.Domain.Entities;

namespace AuctionSystem.Api.Infrastructure;

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

    public Task<IEnumerable<Auction>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Auction>>(_db.Auctions.ToList());
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