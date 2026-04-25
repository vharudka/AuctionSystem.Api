using AuctionSystem.Api.Dtos.Bids;
using AuctionSystem.Api.Validators.Bids;
using FluentValidation.TestHelper;

namespace AuctionSystem.Api.Tests.Validators.Bids;

[TestClass]
public class BidQueryParametersValidatorTests
{
    private BidQueryParametersValidator _validator = null!;

    [TestInitialize]
    public void Setup()
    {
        _validator = new BidQueryParametersValidator();
    }

    [TestMethod]
    public void SortBy_InvalidValue_ShouldHaveError()
    {
        var model = new BidQueryParameters("invalid", true, 1, 10);

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.SortBy);
    }

    [TestMethod]
    [DataRow("amount")]
    [DataRow("Amount")]
    [DataRow("AMOUNT")]
    [DataRow("placedat")]
    [DataRow("Placedat")]
    [DataRow("PLACEDAT")]
    [DataRow("userId")]
    [DataRow("UserId")]
    [DataRow("USERID")]
    public void SortBy_ValidValues_ShouldNotHaveError(string sortBy)
    {
        var model = new BidQueryParameters(sortBy, true, 1, 10);

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveValidationErrorFor(x => x.SortBy);
    }

    [TestMethod]
    public void Page_LessThanOrEqualZero_ShouldHaveError()
    {
        var model = new BidQueryParameters("amount", true, 0, 10);

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Page);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(101)]
    public void PageSize_Invalid_ShouldHaveError(int pageSize)
    {
        var model = new BidQueryParameters("amount", true, 1, pageSize);

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.PageSize);
    }

    [TestMethod]
    public void ValidModel_ShouldNotHaveAnyErrors()
    {
        var model = new BidQueryParameters("amount", true, 1, 10);

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveAnyValidationErrors();
    }
}