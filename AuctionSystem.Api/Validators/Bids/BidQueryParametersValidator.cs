using AuctionSystem.Api.Dtos.Bids;
using FluentValidation;

namespace AuctionSystem.Api.Validators.Bids;

public class BidQueryParametersValidator : AbstractValidator<BidQueryParameters>
{
    public BidQueryParametersValidator()
    {
        Include(new BaseQueryParametersValidator());

        RuleFor(x => x.SortBy)
            .Must(s => string.IsNullOrEmpty(s) ||
                       s.Equals("amount", StringComparison.OrdinalIgnoreCase) ||
                       s.Equals("placedat", StringComparison.OrdinalIgnoreCase) ||
                       s.Equals("userId", StringComparison.OrdinalIgnoreCase))
            .WithMessage("SortBy must be one of: amount, placedat, userId.");
    }
}