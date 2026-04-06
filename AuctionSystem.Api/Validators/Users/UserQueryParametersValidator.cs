using AuctionSystem.Api.Dtos.Users;
using FluentValidation;

namespace AuctionSystem.Api.Validators.Users;

public class UserQueryParametersValidator : AbstractValidator<UserQueryParameters>
{
    public UserQueryParametersValidator()
    {
        Include(new BaseQueryParametersValidator());

        RuleFor(x => x.SortBy)
            .Must(s => string.IsNullOrEmpty(s) ||
                       s.Equals("username", StringComparison.OrdinalIgnoreCase) ||
                       s.Equals("name", StringComparison.OrdinalIgnoreCase) ||
                       s.Equals("surname", StringComparison.OrdinalIgnoreCase))
            .WithMessage("SortBy must be one of: username, name, surname.");
    }
}