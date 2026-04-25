using AuctionSystem.Api.Dtos.Users;
using AuctionSystem.Api.Validators.Users;
using FluentValidation.TestHelper;

namespace AuctionSystem.Api.Tests.Validators.Users;

[TestClass]
public class UpdateUserRequestValidatorTests
{
    private UpdateUserRequestValidator _validator = null!;

    [TestInitialize]
    public void Setup()
    {
        _validator = new UpdateUserRequestValidator();
    }

    [TestMethod]
    public void Name_Empty_ShouldHaveError()
    {
        var model = new UpdateUserRequest("", "TestSurname", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [TestMethod]
    public void Name_TooShort_ShouldHaveError()
    {
        var model = new UpdateUserRequest("T", "TestSurname", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [TestMethod]
    public void Surname_Empty_ShouldHaveError()
    {
        var model = new UpdateUserRequest("TestName", "", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Surname);
    }

    [TestMethod]
    public void Surname_TooShort_ShouldHaveError()
    {
        var model = new UpdateUserRequest("TestName", "T", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Surname);
    }

    [TestMethod]
    public void ValidModel_ShouldPassValidation()
    {
        var model = new UpdateUserRequest("TestName", "TestSurname", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveAnyValidationErrors();
    }
}