using FluentValidation;
using Keezag.Domain.Context.Interfaces;
using Keezag.Domain.Context.Services;

namespace Keezag.Domain.Context.Entities
{
    public class UserValidation : AbstractValidator<User>
    {
        public static IUserService _userService;
        public UserValidation(IUserService userService)
        {
            _userService = userService;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 50).WithMessage("Name must be a minimum of 3 characters and a maximum of 50.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not valid.")
                .Must(UserExists).WithMessage("Email is already registered.");

            RuleFor(x => x.Profiles)
                .NotNull().WithMessage("Profile is required.");
        }

        private static bool UserExists(string email)
        {
            return _userService.GetByEmail(email) == null;
        }
    }
}
