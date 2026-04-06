using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Dtos;

namespace AuctionSystem.Api.Infrastructure;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<PagedResult<User>> GetAllAsync(UserQueryParameters query);
    Task<User?> GetByUsernameAsync(string username);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task SaveChangesAsync();
}