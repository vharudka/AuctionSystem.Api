using AuctionSystem.Api.Dtos;
using FluentValidation;

namespace AuctionSystem.Api.Validators;

public class UserQueryParametersValidator : AbstractValidator<UserQueryParameters>
{
    public UserQueryParametersValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than 0.");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100)
            .WithMessage("PageSize must be between 1 and 100.");

        RuleFor(x => x.SortBy)
            .Must(s => string.IsNullOrEmpty(s) ||
                       s.Equals("username", StringComparison.OrdinalIgnoreCase) ||
                       s.Equals("name", StringComparison.OrdinalIgnoreCase) ||
                       s.Equals("surname", StringComparison.OrdinalIgnoreCase))
            .WithMessage("SortBy must be one of: username, name, surname.");
    }
}