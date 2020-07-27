using FluentValidation;
using Keezag.Domain.Context.Entities;
using Keezag.Domain.Context.Interfaces;
using Keezag.Domain.Context.Services;

namespace Keezag.Tests
{
    public class UserValidationWithoutDatabase : AbstractValidator<User>
    {
        public UserValidationWithoutDatabase()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 50).WithMessage("Name must be a minimum of 3 characters and a maximum of 50.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not valid.");

            RuleFor(x => x.Profiles)
                .NotNull().WithMessage("Profile is required.");
        }

    }
}
