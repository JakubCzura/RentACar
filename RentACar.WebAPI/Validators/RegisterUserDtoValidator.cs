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
                .NotEmpty().WithMessage("Name can't be empty")
                .MinimumLength(2).WithMessage("Email must contain at least 2 characters");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname can't be empty")
                .MinimumLength(2).WithMessage("Email must contain at least 2 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email can't be empty")
                .MinimumLength(4).WithMessage("Email must contain at least 4 characters")
                .EmailAddress().WithMessage("Email should be in correct format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password can't be empty")
                .MinimumLength(2).WithMessage("Password must contain at least 2 characters"); 

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number can't be empty")
                .MinimumLength(5).WithMessage("Phone number must contain at least 5 characters"); ;

            RuleFor(x => x.Email)
               .CustomAsync(async (value, context, cancellationToken) =>
               {
                   IEnumerable<User> users = await _userService.GetAllAsync();
                   bool isEmailUsed = users.Any(x => x.Email == value);
                   if (isEmailUsed)
                   {
                       context.AddFailure(nameof(RegisterUserDto.Email), "E-mail has been already taken");
                   }
               });
        }
    }
}
