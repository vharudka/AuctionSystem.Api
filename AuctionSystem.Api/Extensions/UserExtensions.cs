using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuctionSystem.Api.Extensions;

public static class UserExtensions
{
    public static int GetUserId(this ClaimsPrincipal user)
    {
        return int.Parse(user.FindFirstValue(JwtRegisteredClaimNames.Sub)!);
    }
}