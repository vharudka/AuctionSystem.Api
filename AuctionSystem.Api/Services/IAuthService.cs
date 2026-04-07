using AuctionSystem.Api.Dtos.Auths;

namespace AuctionSystem.Api.Services;

public interface IAuthService
{
    Task<string> LoginAsync(LoginRequest request);
}