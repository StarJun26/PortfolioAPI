using FluentValidation;

namespace Portfolio.Application.Features.UserFeatures.CreateUser
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator() 
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(3, 50);
            RuleFor(x => x.LastName).NotNull().NotEmpty().Length(3, 50);
            RuleFor(x => x.Role).NotNull()
                .IsInEnum().WithMessage("Please add a valid role");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password should not be empty")
                .MinimumLength(8).WithMessage("Password should contain at least 8 characters")
                .MaximumLength(16).WithMessage("Password should not exceed 16 characters")
                .Matches(@"[A-Z]+").WithMessage("Password should contain at least one uppercase letter")
                .Matches(@"[a-z]+").WithMessage("Password should contain at least one lowercase letter");
            RuleFor(x => x.Password)
                .Equal(x => x.ConfirmPassword)
                .When(x => !String.IsNullOrWhiteSpace(x.Password));
        }

        private bool MatchPasswordAndConfirmation(string confirmPassword)
        {
            //...
            return true;
        }
    }
}
