using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Domain.Exceptions;
using AuctionSystem.Api.Dtos.Users;
using AuctionSystem.Api.Infrastructure.Repositories;

namespace AuctionSystem.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<UserResponse>> GetAllAsync(UserQueryParameters query)
    {
        var result = await _repository.GetAllAsync(query);

        var mapped = result.Items.Select(u =>
            new UserResponse(u.Id, u.Username, u.Name, u.Surname));

        return new PagedResult<UserResponse>(
            mapped,
            result.Page,
            result.PageSize,
            result.TotalCount
        );
    }

    public async Task<UserResponse?> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
        {
            throw new UserNotFoundException(id);
        }

        return new UserResponse(user.Id, user.Username, user.Name, user.Surname);
    }

    public async Task<UserResponse> CreateAsync(CreateUserRequest request)
    {
        var existing = await _repository.GetByUsernameAsync(request.Username);
        if (existing != null)
        {
            throw new UsernameAlreadyExistsException(request.Username);
        }

        var user = new User
        {
            Username = request.Username,
            Name = request.Name,
            Surname = request.Surname,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();

        return new UserResponse(user.Id, user.Username, user.Name, user.Surname);
    }

    public async Task<UserResponse?> UpdateAsync(int id, UpdateUserRequest request)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
        {
            throw new UserNotFoundException(id);
        }

        user.Name = request.Name;
        user.Surname = request.Surname;

        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        }

        await _repository.UpdateAsync(user);
        await _repository.SaveChangesAsync();

        return new UserResponse(user.Id, user.Username, user.Name, user.Surname);
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null)
        {
            return;
        }

        await _repository.DeleteAsync(user);
        await _repository.SaveChangesAsync();
    }
}