using AuctionSystem.Api.Dtos.Bids;
using FluentValidation;

namespace AuctionSystem.Api.Validators.Bids;

public class CreateBidRequestValidator : AbstractValidator<CreateBidRequest>
{
    public CreateBidRequestValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("Bid amount must be greater than 0.");
    }
}