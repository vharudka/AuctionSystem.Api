using AuctionSystem.Api.Domain.Entities;

namespace AuctionSystem.Api.Infrastructure;

public interface IBidRepository
{
    Task<IEnumerable<Bid>> GetBidsForAuctionAsync(int auctionId);
    Task AddAsync(Bid bid);
    Task SaveChangesAsync();
}