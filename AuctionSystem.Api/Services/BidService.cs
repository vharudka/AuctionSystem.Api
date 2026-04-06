using AuctionSystem.Api.Dtos;
using AuctionSystem.Api.Infrastructure.Repositories;

namespace AuctionSystem.Api.Services;

public class BidService : IBidService
{
    private readonly IBidRepository _repository;
    public BidService(IBidRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<BidDto>> GetBidsForAuctionAsync(int auctionId)
    {
        return Task.FromResult<IEnumerable<BidDto>>(new List<BidDto>());
    }

    public Task<BidDto> CreateAsync(CreateBidDto dto)
    {
        return Task.FromResult(new BidDto());
    }
}