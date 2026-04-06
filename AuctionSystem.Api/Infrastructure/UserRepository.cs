using AuctionSystem.Api.Domain.Entities;

namespace AuctionSystem.Api.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly AuctionDbContext _db;
    public UserRepository(AuctionDbContext db)
    {
        _db = db;
    }

    public Task<User?> GetByIdAsync(int id)
    {
        return _db.Users.FindAsync(id).AsTask();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<User>>(_db.Users.ToList());
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