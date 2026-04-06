using AuctionSystem.Api.Dtos;
using AuctionSystem.Api.Infrastructure;

namespace AuctionSystem.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<UserDto>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<UserDto>>(new List<UserDto>());
    }

    public Task<UserDto?> GetByIdAsync(int id)
    {
        return Task.FromResult<UserDto?>(null);
    }

    public Task<UserDto> CreateAsync(CreateUserDto dto)
    {
        return Task.FromResult(new UserDto());
    }

    public Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto)
    {
        return Task.FromResult<UserDto?>(null);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return Task.FromResult(false);
    }
}