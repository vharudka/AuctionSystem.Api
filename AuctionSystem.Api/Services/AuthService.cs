using AuctionSystem.Api.Domain.Exceptions;
using AuctionSystem.Api.Dtos.Auths;
using AuctionSystem.Api.Helpers;
using AuctionSystem.Api.Infrastructure.Repositories;

namespace AuctionSystem.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _users;
    private readonly IConfiguration _config;

    public AuthService(IUserRepository users, IConfiguration config)
    {
        _users = users;
        _config = config;
    }

    public async Task<string> LoginAsync(LoginRequest request)
    {
        var user = await _users.GetByUsernameAsync(request.Username);
        if (user == null)
        {
            throw new InvalidCredentialsException();
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            throw new InvalidCredentialsException();
        }

        return JwtTokenHelper.GenerateToken(user, _config);
    }
}