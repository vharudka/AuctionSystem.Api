using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Dtos.Users;

namespace AuctionSystem.Api.Services;

public interface IUserService
{
    Task<PagedResult<UserResponse>> GetAllAsync(UserQueryParameters query);
    Task<UserResponse?> GetByIdAsync(int id);
    Task<UserResponse> CreateAsync(CreateUserRequest request);
    Task<UserResponse?> UpdateAsync(int id, UpdateUserRequest request);
    Task DeleteAsync(int id);
}