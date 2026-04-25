using AuctionSystem.Api.Domain.Entities;
using AuctionSystem.Api.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AuctionSystem.Api.Tests.Helpers;

[TestClass]
public class JwtTokenHelperTests
{
    private IConfiguration _config = null!;
    private User _user = null!;

    [TestInitialize]
    public void Setup()
    {
        var inMemorySettings = new Dictionary<string, string?>
        {
            { "Jwt:Key", "supersecretkey1234567890supersecret" },
            { "Jwt:Issuer", "TestIssuer" },
            { "Jwt:Audience", "TestAudience" },
            { "Jwt:ExpiresMinutes", "60" }
        };

        _config = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        _user = new User
        {
            Id = 1,
            Username = "testuser"
        };
    }

    [TestMethod]
    public void GenerateToken_ShouldContainCorrectClaims()
    {
        var tokenString = JwtTokenHelper.GenerateToken(_user, _config);

        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(tokenString);

        Assert.AreEqual("1", token.Claims.First(c => c.Type == "id").Value);
        Assert.AreEqual("testuser", token.Claims.First(c => c.Type == "username").Value);
    }

    [TestMethod]
    public void GenerateToken_ShouldHaveCorrectIssuerAndAudience()
    {
        var tokenString = JwtTokenHelper.GenerateToken(_user, _config);

        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(tokenString);

        Assert.AreEqual("TestIssuer", token.Issuer);
        Assert.AreEqual("TestAudience", token.Audiences.First());
    }

    [TestMethod]
    public void GenerateToken_ShouldHaveValidSignature()
    {
        var tokenString = JwtTokenHelper.GenerateToken(_user, _config);

        var handler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "TestIssuer",

            ValidateAudience = true,
            ValidAudience = "TestAudience",

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
            ),

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        handler.ValidateToken(tokenString, validationParameters, out var validatedToken);

        Assert.IsNotNull(validatedToken);
    }

    [TestMethod]
    public void GenerateToken_ShouldSetExpirationCorrectly()
    {
        var before = DateTime.UtcNow;
        var tokenString = JwtTokenHelper.GenerateToken(_user, _config);
        var after = DateTime.UtcNow;

        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(tokenString);

        var expires = token.ValidTo;

        Assert.IsTrue(expires > before.AddMinutes(59));
        Assert.IsTrue(expires <= after.AddMinutes(60));
    }
}