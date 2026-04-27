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
    private readonly ICategoryRepository _categoryRepository;

    public AuctionService(IAuctionRepository auctionRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
    {
        _auctionRepository = auctionRepository;
        _userRepository = userRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<AuctionResponse> CreateAsync(int userId, CreateAuctionRequest request)
    {
        _ = await _userRepository.GetByIdAsync(userId) ?? throw new UserNotFoundException(userId);
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId) ?? throw new CategoryNotFoundException(request.CategoryId);

        var auction = new Auction
        {
            Title = request.Title,
            Description = request.Description,
            StartingPrice = request.StartingPrice,
            CurrentPrice = request.StartingPrice,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Category = category,
            OwnerId = userId
        };

        await _auctionRepository.AddAsync(auction);
        await _auctionRepository.SaveChangesAsync();

        return Map(auction);
    }

    public async Task<AuctionResponse> UpdateAsync(int id, int userId, UpdateAuctionRequest request)
    {
        var auction = await _auctionRepository.GetByIdAsync(id) ?? throw new AuctionNotFoundException(id);
        _ = await _userRepository.GetByIdAsync(userId) ?? throw new UserNotFoundException(userId);
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId) ?? throw new CategoryNotFoundException(request.CategoryId);

        if (auction.OwnerId != userId)
        {
            throw new AuctionOwnershipException(id, userId);
        }

        var status = AuctionStatusCalculator.GetStatus(auction.StartDate, auction.EndDate);
        if (status != AuctionStatus.Draft)
        {
            throw new AuctionNotDraftException();
        }

        auction.Title = request.Title;
        auction.Description = request.Description;
        auction.CategoryId = request.CategoryId;
        auction.StartingPrice = request.StartingPrice;
        auction.CurrentPrice = request.StartingPrice;
        auction.StartDate = request.StartDate;
        auction.EndDate = request.EndDate;
        auction.Category = category;

        await _auctionRepository.UpdateAsync(auction);
        await _auctionRepository.SaveChangesAsync();

        return Map(auction);
    }

    public async Task DeleteAsync(int id, int userId)
    {
        var auction = await _auctionRepository.GetByIdAsync(id) ?? throw new AuctionNotFoundException(id);
        _ = await _userRepository.GetByIdAsync(userId) ?? throw new UserNotFoundException(userId);
        if (auction.OwnerId != userId)
        {
            throw new AuctionOwnershipException(id, userId);
        }

        var status = AuctionStatusCalculator.GetStatus(auction.StartDate, auction.EndDate);
        if (status != AuctionStatus.Draft)
        {
            throw new AuctionNotDraftException();
        }

        await _auctionRepository.DeleteAsync(auction);
        await _auctionRepository.SaveChangesAsync();
    }

    public async Task<AuctionResponse> GetByIdAsync(int id)
    {
        var auction = await _auctionRepository.GetByIdAsync(id);
        return auction == null ? throw new AuctionNotFoundException(id) : Map(auction);
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
        => new
        (
            a.Id,
            a.Title,
            a.Description,
            a.Category?.Name ?? "",
            a.Category?.Id ?? -1,
            a.StartingPrice,
            a.CurrentPrice,
            a.StartDate,
            a.EndDate,
            AuctionStatusCalculator.GetStatus(a.StartDate, a.EndDate).ToString(),
            a.OwnerId
        );
}