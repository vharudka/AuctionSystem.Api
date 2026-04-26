using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Domain.Enums;
using AuctionSystem.Api.Domain.Exceptions;
using AuctionSystem.Api.Dtos.Bids;
using AuctionSystem.Api.Helpers;
using AuctionSystem.Api.Infrastructure.Repositories;

namespace AuctionSystem.Api.Services;

public class BidService : IBidService
{
    private readonly IBidRepository _bidRepository;
    private readonly IAuctionRepository _auctionRepository;
    private readonly IUserRepository _userRepository;
    public BidService(IBidRepository bidRepository,
                      IAuctionRepository auctionRepository,
                      IUserRepository userRepository)
    {
        _bidRepository = bidRepository;
        _auctionRepository = auctionRepository;
        _userRepository = userRepository;
    }

    public async Task<PagedResult<BidResponse>> GetAllAsync(int auctionId, BidQueryParameters query)
    {
        var auction = await _auctionRepository.GetByIdAsync(auctionId) ?? throw new AuctionNotFoundException(auctionId);
        var result = await _bidRepository.GetAllByAuctionIdAsync(auctionId, query);

        return new PagedResult<BidResponse>(
            result.Items.Select(b => new BidResponse(
                b.Id,
                b.AuctionId,
                b.UserId,
                b.Amount,
                b.PlacedAt
            )),
            result.Page,
            result.PageSize,
            result.TotalCount
        );
    }

    public async Task<BidResponse> CreateAsync(int auctionId, int userId, CreateBidRequest request)
    {
        var auction = await _auctionRepository.GetByIdAsync(auctionId) ?? throw new AuctionNotFoundException(auctionId);
        _ = await _userRepository.GetByIdAsync(userId) ?? throw new UserNotFoundException(userId);
        var status = AuctionStatusCalculator.GetStatus(auction.StartDate, auction.EndDate);

        switch (status)
        {
            case AuctionStatus.Draft:
                throw new AuctionNotActiveException();

            case AuctionStatus.Finished:
                throw new AuctionExpiredException();

            case AuctionStatus.Active:
                if (request.Amount <= auction.CurrentPrice)
                    throw new BidTooLowException(auction.CurrentPrice);
                break;
        }

        var bid = new Bid
        {
            AuctionId = auctionId,
            UserId = userId,
            Amount = request.Amount,
            PlacedAt = DateTime.UtcNow
        };

        await _bidRepository.AddAsync(bid);

        auction.CurrentPrice = request.Amount;

        await _auctionRepository.SaveChangesAsync();
        await _bidRepository.SaveChangesAsync();

        return new BidResponse(
            bid.Id,
            bid.AuctionId,
            bid.UserId,
            bid.Amount,
            bid.PlacedAt
        );
    }
}