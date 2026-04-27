using AuctionSystem.Api.Domain.Entities;

namespace AuctionSystem.Api.Infrastructure.Repositories;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(int id);
    Task<IReadOnlyList<Category>> GetAllAsync();
}