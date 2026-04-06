using AuctionSystem.Api.Dtos;

namespace AuctionSystem.Api.Services;

public interface IAuctionService
{
    Task<IEnumerable<AuctionDto>> GetAllAsync();
    Task<AuctionDto?> GetByIdAsync(int id);
    Task<AuctionDto> CreateAsync(CreateAuctionDto dto);
    Task<AuctionDto?> UpdateAsync(int id, UpdateAuctionDto dto);
    Task<bool> DeleteAsync(int id);
}