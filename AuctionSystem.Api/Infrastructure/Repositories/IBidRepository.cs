using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Dtos.Bids;

namespace AuctionSystem.Api.Infrastructure.Repositories;

public interface IBidRepository
{
    Task<PagedResult<Bid>> GetBidsForAuctionAsync(int auctionId, BidQueryParameters query);
    Task AddAsync(Bid bid);
    Task SaveChangesAsync();
}