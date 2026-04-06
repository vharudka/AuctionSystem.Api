using AuctionSystem.Api.Dtos.Users;
using FluentValidation;

namespace AuctionSystem.Api.Validators.Users;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MinimumLength(2)
            .WithMessage("Name must be at least 2 characters long.");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithMessage("Surname is required.")
            .MinimumLength(2)
            .WithMessage("Surname must be at least 2 characters long.");
    }
};