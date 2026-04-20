using AuctionSystem.Api.Dtos.Auths;
using AuctionSystem.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService auth, ILogger<AuthController> logger)
    {
        _auth = auth;
        _logger = logger;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        _logger.LogInformation("Login request received for username {Username}", request.Username);

        var token = await _auth.LoginAsync(request);

        _logger.LogInformation("User {Username} logged in successfully", request.Username);

        return Ok(new { token });
    }
}