using FluentValidation;
using RentACar.WebAPI.Models.Dtos;

namespace RentACar.WebAPI.Validators
{
    public class LogInUserDtoValidator : AbstractValidator<LogInUserDto>
    {
        public LogInUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email can't be empty");

            RuleFor(x => x.Password)
             .NotEmpty().WithMessage("Password can't be empty");
        }
    }
}