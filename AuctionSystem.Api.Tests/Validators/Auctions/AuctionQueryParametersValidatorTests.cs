using AuctionSystem.Api.Domain.Enums;
using AuctionSystem.Api.Dtos.Auctions;
using AuctionSystem.Api.Validators.Auctions;
using FluentValidation.TestHelper;

namespace AuctionSystem.Api.Tests.Validators.Auctions;

[TestClass]
public  class AuctionQueryParametersValidatorTests
{
    private AuctionQueryParametersValidator _validator = null!;

    [TestInitialize]
    public void Setup()
    {
        _validator = new AuctionQueryParametersValidator();
    }

    [TestMethod]
    public void SortBy_InvalidValue_ShouldHaveError()
    {
        var model = new AuctionQueryParameters(null, AuctionStatus.Active, null, "invalid", true, 1, 10);

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.SortBy);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(null)]
    [DataRow("title")]
    [DataRow("Title")]
    [DataRow("TITLE")]
    [DataRow("startdate")]
    [DataRow("startDate")]
    [DataRow("STARTDATE")]
    [DataRow("enddate")]
    [DataRow("endDate")]
    [DataRow("ENDDATE")]
    [DataRow("currentprice")]
    [DataRow("currentPrice")]
    [DataRow("CURRENTPRICE")]
    public void SortBy_ValidValues_ShouldNotHaveError(string sortBy)
    {
        var model = new AuctionQueryParameters(null, AuctionStatus.Active, null, sortBy, true, 1, 10);

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveValidationErrorFor(x => x.SortBy);
    }

    [TestMethod]
    public void Page_LessThanOrEqualZero_ShouldHaveError()
    {
        var model = new AuctionQueryParameters(null, AuctionStatus.Active, null, "title", true, 0, 10);

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Page);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(101)]
    public void PageSize_Invalid_ShouldHaveError(int pageSize)
    {
        var model = new AuctionQueryParameters(null, AuctionStatus.Active, null, "title", true, 1, pageSize);

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.PageSize);
    }

    [TestMethod]
    public void ValidModel_ShouldNotHaveAnyErrors()
    {
        var model = new AuctionQueryParameters(null, AuctionStatus.Active, null, "title", true, 1, 10);

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveAnyValidationErrors();
    }
}