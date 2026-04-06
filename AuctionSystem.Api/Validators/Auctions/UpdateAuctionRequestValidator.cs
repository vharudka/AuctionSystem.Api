using AuctionSystem.Api.Domain.Enums;
using AuctionSystem.Api.Dtos.Auctions;
using FluentValidation;

namespace AuctionSystem.Api.Validators.Auctions;

public class UpdateAuctionRequestValidator : AbstractValidator<UpdateAuctionRequest>
{
    public UpdateAuctionRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(100)
            .WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(1000)
            .WithMessage("Description cannot exceed 1000 characters.");

        RuleFor(x => x.StartingPrice)
            .GreaterThan(0)
            .WithMessage("Starting price must be greater than 0.");

        RuleFor(x => x.StartDate)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("Start date must be in the future.");

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date must be later than start date.");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("Category is required.");
    }
}