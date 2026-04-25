using AuctionSystem.Api.Dtos.Auctions;
using AuctionSystem.Api.Validators.Auctions;
using FluentValidation.TestHelper;

namespace AuctionSystem.Api.Tests.Validators.Auctions;

[TestClass]
public class CreateAuctionRequestValidatorTests
{
    private CreateAuctionRequestValidator _validator = null!;
    private DateTime _now;

    [TestInitialize]
    public void Setup()
    {
        _validator = new CreateAuctionRequestValidator();
        _now = DateTime.UtcNow;
    }

    [TestMethod]
    public void Title_Empty_ShouldHaveError()
    {
        var model = new CreateAuctionRequest("",
                                             "TestDescription",
                                             10,
                                             _now.AddHours(1),
                                             _now.AddHours(2),
                                             "TestCategory");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [TestMethod]
    public void Title_TooLong_ShouldHaveError()
    {
        var model = new CreateAuctionRequest(new string('x', 101),
                                             "TestDescription",
                                             10,
                                             _now.AddHours(1),
                                             _now.AddHours(2),
                                             "TestCategory");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [TestMethod]
    public void Description_Empty_ShouldHaveError()
    {
        var model = new CreateAuctionRequest("TestTitle",
                                             "",
                                             10,
                                             _now.AddHours(1),
                                             _now.AddHours(2),
                                             "TestCategory");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    [TestMethod]
    public void Description_TooLong_ShouldHaveError()
    {
        var model = new CreateAuctionRequest("TestTitle",
                                             new string('x', 1001),
                                             10,
                                             _now.AddHours(1),
                                             _now.AddHours(2),
                                             "TestCategory");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    [TestMethod]
    public void Category_Empty_ShouldHaveError()
    {
        var model = new CreateAuctionRequest("TestTitle",
                                             "TestDescription",
                                             10,
                                             _now.AddHours(1),
                                             _now.AddHours(2),
                                             "");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Category);
    }

    [TestMethod]
    public void Category_TooLong_ShouldHaveError()
    {
        var model = new CreateAuctionRequest("TestTitle",
                                             "TestDescription",
                                             10,
                                             _now.AddHours(1),
                                             _now.AddHours(2),
                                             new string('x', 101));

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Category);
    }

    [TestMethod]
    public void StartingPrice_TooSmall_ShouldHaveError()
    {
        var model = new CreateAuctionRequest("TestTitle",
                                             "TestDescription",
                                             0,
                                             _now.AddHours(1),
                                             _now.AddHours(2),
                                             "TestCategory");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.StartingPrice);
    }

    [TestMethod]
    public void StartDate_LessThenNow_ShouldHaveError()
    {
        var model = new CreateAuctionRequest("TestTitle",
                                             "TestDescription",
                                             10,
                                             _now.AddHours(-1),
                                             _now.AddHours(2),
                                             "TestCategory");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.StartDate);
    }

    [TestMethod]
    public void EndDate_LessThenStartDate_ShouldHaveError()
    {
        var model = new CreateAuctionRequest("TestTitle",
                                             "TestDescription",
                                             10,
                                             _now.AddHours(2),
                                             _now.AddHours(1),
                                             "TestCategory");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.EndDate);
    }

    [TestMethod]
    public void EndDate_EqualToStartDate_ShouldHaveError()
    {
        var model = new CreateAuctionRequest("TestTitle",
                                             "TestDescription",
                                             10,
                                             _now.AddHours(1),
                                             _now.AddHours(1),
                                             "TestCategory");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.EndDate);
    }

    [TestMethod]
    public void ValidModel_ShouldPassValidation()
    {
        var model = new CreateAuctionRequest("TestTitle",
                                             "TestDescription",
                                             10,
                                             _now.AddHours(1),
                                             _now.AddHours(2),
                                             "TestCategory");

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveValidationErrorFor(x => x.EndDate);
    }
}