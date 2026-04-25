using AuctionSystem.Api.Domain.Enums;
using AuctionSystem.Api.Helpers;

namespace AuctionSystem.Api.Tests.Helpers;

[TestClass]
public class AuctionStatusCalculatorTests
{
    private DateTime _now;

    [TestInitialize]
    public void Setup()
    {
        _now = DateTime.UtcNow;
    }

    [TestMethod]
    public void GetStatus_StartDateInFuture_ReturnsDraft()
    {
        var start = _now.AddHours(1);
        var end = _now.AddHours(2);

        var result = AuctionStatusCalculator.GetStatus(start, end);

        Assert.AreEqual(AuctionStatus.Draft, result);
    }

    [TestMethod]
    public void GetStatus_EndDateInPast_ReturnsFinished()
    {
        var start = _now.AddHours(-2);
        var end = _now.AddHours(-1);

        var result = AuctionStatusCalculator.GetStatus(start, end);

        Assert.AreEqual(AuctionStatus.Finished, result);
    }

    [TestMethod]
    public void GetStatus_EndDateEqualsNow_ReturnsFinished()
    {
        var start = _now.AddHours(-1);
        var end = _now; 

        var result = AuctionStatusCalculator.GetStatus(start, end);

        Assert.AreEqual(AuctionStatus.Finished, result);
    }

    [TestMethod]
    public void GetStatus_StartDatePast_EndDateFuture_ReturnsActive()
    {
        var start = _now.AddHours(-1);
        var end = _now.AddHours(1);

        var result = AuctionStatusCalculator.GetStatus(start, end);

        Assert.AreEqual(AuctionStatus.Active, result);
    }
}