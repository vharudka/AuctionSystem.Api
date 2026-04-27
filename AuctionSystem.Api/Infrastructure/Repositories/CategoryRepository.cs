using AuctionSystem.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionSystem.Api.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AuctionDbContext _db;

    public CategoryRepository(AuctionDbContext db)
    {
        _db = db;
    }

    public Task<Category?> GetByIdAsync(int id)
    {
        return _db.Categories.FindAsync(id).AsTask();
    }

    public async Task<IReadOnlyList<Category>> GetAllAsync()
    {
        return await _db.Categories.OrderBy(c => c.Name)
                                   .ToListAsync();
    }
}