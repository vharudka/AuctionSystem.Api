using AuctionSystem.Api.Dtos;

namespace AuctionSystem.Api.Services;

public interface IBidService
{
    Task<IEnumerable<BidDto>> GetBidsForAuctionAsync(int auctionId);
    Task<BidDto> CreateAsync(CreateBidDto dto);
}