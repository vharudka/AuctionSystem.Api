using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Dtos.Users;
using Microsoft.EntityFrameworkCore;

namespace AuctionSystem.Api.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuctionDbContext _db;

    public UserRepository(AuctionDbContext db)
    {
        _db = db;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _db.Users.FindAsync(id);
    }

    public async Task<PagedResult<User>> GetAllAsync(UserQueryParameters query)
    {
        var users = _db.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            users = users.Where(u =>
                u.Username.Contains(query.Search) ||
                u.Name.Contains(query.Search) ||
                u.Surname.Contains(query.Search));
        }


        users = query.SortBy?.ToLower() switch
        {
            "username" => query.Desc
                ? users.OrderByDescending(u => u.Username)
                : users.OrderBy(u => u.Username),

            "name" => query.Desc
                ? users.OrderByDescending(u => u.Name)
                : users.OrderBy(u => u.Name),

            "surname" => query.Desc
                ? users.OrderByDescending(u => u.Surname)
                : users.OrderBy(u => u.Surname),

            _ => users.OrderBy(u => u.Id)
        };

        var totalCount = await users.CountAsync();
        var items = await users.Skip((query.Page - 1) * query.PageSize)
                               .Take(query.PageSize)
                               .ToListAsync();

        return new PagedResult<User>(
            items,
            query.Page,
            query.PageSize,
            totalCount
        );
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public Task AddAsync(User user)
    {
        return _db.Users.AddAsync(user).AsTask();
    }

    public Task UpdateAsync(User user)
    {
        _db.Users.Update(user);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(User user)
    {
        _db.Users.Remove(user);

        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        return _db.SaveChangesAsync();
    }
}