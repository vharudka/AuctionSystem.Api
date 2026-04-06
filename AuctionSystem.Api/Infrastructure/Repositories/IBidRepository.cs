using AuctionSystem.Api.Domain.Entities;

namespace AuctionSystem.Api.Infrastructure.Repositories;

public interface IBidRepository
{
    Task<IEnumerable<Bid>> GetBidsForAuctionAsync(int auctionId);
    Task AddAsync(Bid bid);
    Task SaveChangesAsync();
}