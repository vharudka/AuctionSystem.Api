using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Dtos.Auctions;

namespace AuctionSystem.Api.Services;

public interface IAuctionService
{
    Task<PagedResult<AuctionResponse>> GetAllAsync(AuctionQueryParameters query);
    Task<AuctionResponse> GetByIdAsync(int id);
    Task<AuctionResponse> CreateAsync(CreateAuctionRequest request);
    Task<AuctionResponse> UpdateAsync(int id, UpdateAuctionRequest request);
    Task DeleteAsync(int id);
}