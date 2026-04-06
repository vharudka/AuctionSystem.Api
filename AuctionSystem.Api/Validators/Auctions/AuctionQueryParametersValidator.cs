using AuctionSystem.Api.Dtos.Auctions;
using FluentValidation;

namespace AuctionSystem.Api.Validators.Auctions;

public class AuctionQueryParametersValidator : AbstractValidator<AuctionQueryParameters>
{
    public AuctionQueryParametersValidator()
    {
        Include(new BaseQueryParametersValidator());

        RuleFor(x => x.SortBy)
            .Must(s => string.IsNullOrEmpty(s) ||
                       s.Equals("title", StringComparison.OrdinalIgnoreCase) ||
                       s.Equals("startDate", StringComparison.OrdinalIgnoreCase) ||
                       s.Equals("endDate", StringComparison.OrdinalIgnoreCase) ||
                       s.Equals("currentPrice", StringComparison.OrdinalIgnoreCase))
            .WithMessage("SortBy must be one of: title, startDate, endDate, currentPrice.");
    }
}