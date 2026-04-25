using AuctionSystem.Api.Dtos.Bids;
using AuctionSystem.Api.Validators.Bids;
using FluentValidation.TestHelper;

namespace AuctionSystem.Api.Tests.Validators.Bids;

[TestClass]
public class CreateBidRequestValidatorTests
{
    private CreateBidRequestValidator _validator = null!;

    [TestInitialize]
    public void Setup()
    {
        _validator = new CreateBidRequestValidator();
    }

    [TestMethod]
    [DataRow("0")]
    [DataRow("-1")]
    [DataRow("-50")]
    public void Amount_Invalid_ShouldHaveError(string amount)
    {
        // DataRow doesn't support decimal, so we use string and parse it in the test method
        var model = new CreateBidRequest(decimal.Parse(amount));

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Amount);
    }

    [TestMethod]
    [DataRow("1")]
    [DataRow("10")]
    [DataRow("99.99")]
    public void Amount_Valid_ShouldNotHaveError(string amount)
    {
        // DataRow doesn't support decimal, so we use string and parse it in the test method
        var model = new CreateBidRequest(decimal.Parse(amount));

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveValidationErrorFor(x => x.Amount);
    }
}