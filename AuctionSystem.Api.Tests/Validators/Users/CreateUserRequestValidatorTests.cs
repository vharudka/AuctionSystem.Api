using AuctionSystem.Api.Dtos.Users;
using AuctionSystem.Api.Validators.Users;
using FluentValidation.TestHelper;

namespace AuctionSystem.Api.Tests.Validators.Users;

[TestClass]
public class CreateUserRequestValidatorTests
{
    private CreateUserRequestValidator _validator = null!;

    [TestInitialize]
    public void Setup()
    {
        _validator = new CreateUserRequestValidator();
    }

    [TestMethod]
    public void Username_Empty_ShouldHaveError()
    {
        var model = new CreateUserRequest("", "TestName", "TestSurname", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Username);
    }

    [TestMethod]
    public void Username_TooShort_ShouldHaveError()
    {
        var model = new CreateUserRequest("Te", "TestName", "TestSurname", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Username);
    }

    [TestMethod]
    public void Username_TooLong_ShouldHaveError()
    {
        var model = new CreateUserRequest(new string('x', 51), "TestName", "TestSurname", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Username);
    }

    [TestMethod]
    public void Name_Empty_ShouldHaveError()
    {
        var model = new CreateUserRequest("TestUserName", "", "TestSurname", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [TestMethod]
    public void Name_TooShort_ShouldHaveError()
    {
        var model = new CreateUserRequest("TestUserName", "T", "TestSurname", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [TestMethod]
    public void Surname_Empty_ShouldHaveError()
    {
        var model = new CreateUserRequest("TestUserName", "TestName", "", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Surname);
    }

    [TestMethod]
    public void Surname_TooShort_ShouldHaveError()
    {
        var model = new CreateUserRequest("TestUserName", "TestName", "T", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Surname);
    }

    [TestMethod]
    public void ValidModel_ShouldPassValidation()
    {
        var model = new CreateUserRequest("TestUserName", "TestName", "TestSurname", "TestPassword");

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveAnyValidationErrors();
    }
}