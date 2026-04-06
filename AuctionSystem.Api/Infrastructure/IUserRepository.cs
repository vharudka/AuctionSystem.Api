using AuctionSystem.Api.Domain.Entities;

namespace AuctionSystem.Api.Infrastructure;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task SaveChangesAsync();
}