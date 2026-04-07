using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Dtos.Bids;

namespace AuctionSystem.Api.Services;

public interface IBidService
{
    Task<PagedResult<BidResponse>> GetBidsAsync(int auctionId, BidQueryParameters query);
    Task<BidResponse> CreateAsync(int auctionId, int userId, CreateBidRequest request);
}