using FluentValidation;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        private readonly IUserService _userService;

        public RegisterUserDtoValidator(IUserService userService)
        {
            _userService = userService;

            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name can't be empty");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname can't be empty");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email can't be empty")
                .EmailAddress().WithMessage("Niepoprawny format e-mail");

            RuleFor(x => x.Password)
             .NotEmpty().WithMessage("Password can't be empty");

            RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number can't be empty");

            RuleFor(x => x.Email)
               .CustomAsync(async (value, context, cancellationToken) =>
               {
                   IEnumerable<User> users = await _userService.GetAllAsync();
                   bool isEmailUsed = users.Any(x => x.Email == value);
                   if (isEmailUsed)
                   {
                       context.AddFailure(nameof(RegisterUserDto.Email), "E-mail jest już używany");
                   }
               });
        }
    }
}