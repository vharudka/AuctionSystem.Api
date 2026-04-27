using AuctionSystem.Api.Dtos.Category;

namespace AuctionSystem.Api.Services;

public interface ICategoryService
{
    Task<IReadOnlyList<CategoryResponse>> GetAllAsync();
}