using AuctionSystem.Api.Domain.Entities;

namespace AuctionSystem.Api.Infrastructure.Repositories;

public class BidRepository : IBidRepository
{
    private readonly AuctionDbContext _db;
    public BidRepository(AuctionDbContext db) => _db = db;

    public Task<IEnumerable<Bid>> GetBidsForAuctionAsync(int auctionId) =>
        Task.FromResult<IEnumerable<Bid>>(_db.Bids.Where(b => b.AuctionId == auctionId).ToList());

    public Task AddAsync(Bid bid) => _db.Bids.AddAsync(bid).AsTask();
    public Task SaveChangesAsync() => _db.SaveChangesAsync();
}