using FluentValidation;
using RentACar.WebAPI.Models.Dtos;

namespace RentACar.WebAPI.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name can't be empty");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname can't be empty");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email can't be empty");

            RuleFor(x => x.Password)
             .NotEmpty().WithMessage("Password can't be empty");

            RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number can't be empty");
        }
    }
}
