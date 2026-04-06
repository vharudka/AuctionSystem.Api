using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Domain.Enums;
using AuctionSystem.Api.Domain.Exceptions;
using AuctionSystem.Api.Dtos.Auctions;
using AuctionSystem.Api.Helpers;
using AuctionSystem.Api.Infrastructure.Repositories;

namespace AuctionSystem.Api.Services;

public class AuctionService : IAuctionService
{
    private readonly IAuctionRepository _auctionRepository;
    private readonly IUserRepository _userRepository;

    public AuctionService(IAuctionRepository auctionRepository, IUserRepository userRepository)
    {
        _auctionRepository = auctionRepository;
        _userRepository = userRepository;
    }

    public async Task<AuctionResponse> CreateAsync(CreateAuctionRequest request)
    {
        var seller = await _userRepository.GetByIdAsync(request.OwnerId);
        if (seller == null)
        {
            throw new UserNotFoundException(request.OwnerId);
        }

        var auction = new Auction
        {
            Title = request.Title,
            Description = request.Description,
            StartingPrice = request.StartingPrice,
            CurrentPrice = request.StartingPrice,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Category = request.Category,
            OwnerId = request.OwnerId
        };

        await _auctionRepository.AddAsync(auction);
        await _auctionRepository.SaveChangesAsync();

        return Map(auction);
    }

    public async Task<AuctionResponse> UpdateAsync(int id, UpdateAuctionRequest request)
    {
        var auction = await _auctionRepository.GetByIdAsync(id);
        if (auction == null)
        {
            throw new AuctionNotFoundException(id);
        }

        auction.Title = request.Title;
        auction.Description = request.Description;
        auction.Category = request.Category;
        auction.StartingPrice = request.StartingPrice;
        auction.StartDate = request.StartDate;
        auction.EndDate = request.EndDate;

        await _auctionRepository.UpdateAsync(auction);
        await _auctionRepository.SaveChangesAsync();

        return Map(auction);
    }

    public async Task DeleteAsync(int id)
    {
        var auction = await _auctionRepository.GetByIdAsync(id);
        if (auction == null)
        {
            throw new AuctionNotFoundException(id);
        }

        await _auctionRepository.DeleteAsync(auction);
        await _auctionRepository.SaveChangesAsync();
    }

    public async Task<AuctionResponse> GetByIdAsync(int id)
    {
        var auction = await _auctionRepository.GetByIdAsync(id);
        if (auction == null)
        {
            throw new AuctionNotFoundException(id);
        }

        return Map(auction);
    }

    public async Task<PagedResult<AuctionResponse>> GetAllAsync(AuctionQueryParameters query)
    {
        var result = await _auctionRepository.GetAllAsync(query);

        return new PagedResult<AuctionResponse>(
            result.Items.Select(Map),
            result.Page,
            result.PageSize,
            result.TotalCount
        );
    }

    private static AuctionResponse Map(Auction a)
        => new AuctionResponse(
            a.Id,
            a.Title,
            a.Description,
            a.Category,
            a.StartingPrice,
            a.CurrentPrice,
            a.StartDate,
            a.EndDate,
            AuctionStatusCalculator.GetStatus(a.StartDate, a.EndDate),
            a.OwnerId
        );
}