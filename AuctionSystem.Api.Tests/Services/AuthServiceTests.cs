using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Domain.Exceptions;
using AuctionSystem.Api.Dtos.Auths;
using AuctionSystem.Api.Infrastructure.Repositories;
using AuctionSystem.Api.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace AuctionSystem.Api.Tests.Services;

[TestClass]
public class AuthServiceTests
{
    private Mock<IUserRepository> _repoMock = null!;
    private IConfiguration _config = null!;
    private AuthService _service = null!;

    [TestInitialize]
    public void Setup()
    {
        _repoMock = new Mock<IUserRepository>();

        var jwtSettings = new Dictionary<string, string?>
            {
                { "Jwt:Key", "supersecretkey1234567890supersecret" },
                { "Jwt:Issuer", "TestIssuer" },
                { "Jwt:Audience", "TestAudience" },
                { "Jwt:ExpiresMinutes", "60" }
            };

        _config = new ConfigurationBuilder()
            .AddInMemoryCollection(jwtSettings)
            .Build();

        _service = new AuthService(_repoMock.Object, _config);
    }

    [TestMethod]
    public async Task LoginAsync_UserNotFound_ThrowsInvalidCredentials()
    {
        _repoMock.Setup(r => r.GetByUsernameAsync("TestUsername"))
                 .ReturnsAsync((User?)null);

        await Assert.ThrowsExactlyAsync<InvalidCredentialsException>(async () =>
            await _service.LoginAsync(new LoginRequest("TestUsername", "pass")));
    }

    [TestMethod]
    public async Task LoginAsync_WrongPassword_ThrowsInvalidCredentials()
    {
        var user = new User
        {
            Username = "TestUsername",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("correctpass")
        };

        _repoMock.Setup(r => r.GetByUsernameAsync("TestUsername"))
                 .ReturnsAsync(user);

        await Assert.ThrowsExactlyAsync<InvalidCredentialsException>(async () =>
            await _service.LoginAsync(new LoginRequest("TestUsername", "wrongpass")));
    }

    [TestMethod]
    public async Task LoginAsync_ValidCredentials_ReturnsToken()
    {
        var user = new User
        {
            Id = 1,
            Username = "TestUsername",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("pass")
        };

        _repoMock.Setup(r => r.GetByUsernameAsync("TestUsername"))
                 .ReturnsAsync(user);

        var token = await _service.LoginAsync(new LoginRequest("TestUsername", "pass"));

        Assert.IsNotEmpty(token);

        _repoMock.Verify(r => r.GetByUsernameAsync("TestUsername"), Times.Once);
    }
}
