using AuctionSystem.Api.Extensions;
using System.Security.Claims;

namespace AuctionSystem.Api.Tests.Extensions;

[TestClass]
public class UserExtensionsTests
{
    [TestMethod]
    public void GetUserId_ValidId_ReturnsParsedValue()
    {
        var claims = new[]
        {
            new Claim("id", "1")
        };
        var identity = new ClaimsIdentity(claims);
        var user = new ClaimsPrincipal(identity);

        var result = user.GetUserId();

        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetUserId_MissingIdClaim_ThrowsException()
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity());

        Assert.ThrowsExactly<ArgumentNullException>(() => user.GetUserId());
    }

    [TestMethod]
    public void GetUserId_InvalidIdValue_ThrowsException()
    {
        var claims = new[]
        {
            new Claim("id", "not-a-number")
        };
        var identity = new ClaimsIdentity(claims);
        var user = new ClaimsPrincipal(identity);

        Assert.ThrowsExactly<FormatException>(() => user.GetUserId());
    }
}