using AuctionSystem.Api.Dtos.Users;
using AuctionSystem.Api.Validators.Users;
using FluentValidation.TestHelper;

namespace AuctionSystem.Api.Tests.Validators.Users;

[TestClass]
public class BidQueryParametersValidatorTests
{
    private UserQueryParametersValidator _validator = null!;

    [TestInitialize]
    public void Setup()
    {
        _validator = new UserQueryParametersValidator();
    }

    [TestMethod]
    public void SortBy_InvalidValue_ShouldHaveError()
    {
        var model = new UserQueryParameters(null, "invalid", true, 1, 10);

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.SortBy);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(null)]
    [DataRow("username")]
    [DataRow("Username")]
    [DataRow("USERNAME")]
    [DataRow("name")]
    [DataRow("Name")]
    [DataRow("NAME")]
    [DataRow("surname")]
    [DataRow("Surname")]
    [DataRow("SURNAME")]
    public void SortBy_ValidValues_ShouldNotHaveError(string sortBy)
    {
        var model = new UserQueryParameters(null, sortBy, true, 1, 10);

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveValidationErrorFor(x => x.SortBy);
    }

    [TestMethod]
    public void Page_LessThanOrEqualZero_ShouldHaveError()
    {
        var model = new UserQueryParameters(null, "name", true, 0, 10);

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Page);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(101)]
    public void PageSize_Invalid_ShouldHaveError(int pageSize)
    {
        var model = new UserQueryParameters(null, "name", true, 1, pageSize);

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.PageSize);
    }

    [TestMethod]
    public void ValidModel_ShouldNotHaveAnyErrors()
    {
        var model = new UserQueryParameters(null, "name", true, 1, 10);

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveAnyValidationErrors();
    }
}