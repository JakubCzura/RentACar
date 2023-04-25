using FluentValidation;
using RentACar.WebAPI.Models.Dtos;

namespace RentACar.WebAPI.Validators
{
    public class LogInUserDtoValidator : AbstractValidator<LogInUserDto>
    {
        public LogInUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email can't be empty")
                .MinimumLength(4).WithMessage("Email must contain at least 4 characters")
                .EmailAddress().WithMessage("Email should be in correct format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password can't be empty")
                .MinimumLength(4).WithMessage("Password must contain at least 4 characters");
        }
    }
}
