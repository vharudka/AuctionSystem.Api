using AuctionSystem.Api.Dtos;
using FluentValidation;

namespace AuctionSystem.Api.Validators;

public class BaseQueryParametersValidator : AbstractValidator<BaseQueryParameters>
{
    public BaseQueryParametersValidator()
    {

        RuleFor(x => x.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than 0.");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100)
            .WithMessage("PageSize must be between 1 and 100.");
    }
}