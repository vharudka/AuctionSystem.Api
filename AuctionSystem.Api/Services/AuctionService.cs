using AuctionSystem.Api.Dtos;
using AuctionSystem.Api.Infrastructure;

namespace AuctionSystem.Api.Services;

public class AuctionService : IAuctionService
{
    private readonly IAuctionRepository _repository;

    public AuctionService(IAuctionRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<AuctionDto>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<AuctionDto>>(new List<AuctionDto>());
    }

    public Task<AuctionDto?> GetByIdAsync(int id)
    {
        return Task.FromResult<AuctionDto?>(null);
    }

    public Task<AuctionDto> CreateAsync(CreateAuctionDto dto)
    {
        return Task.FromResult(new AuctionDto());
    }

    public Task<AuctionDto?> UpdateAsync(int id, UpdateAuctionDto dto)
    {
        return Task.FromResult<AuctionDto?>(null);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.FromResult(false);
    }
}