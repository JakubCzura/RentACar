using FluentValidation;
using RentACar.WebAPI.Models.Dtos;

namespace RentACar.WebAPI.Validators
{
    public class MakePaymentDtoValidator : AbstractValidator<MakePaymentDto>
    {
        public MakePaymentDtoValidator()
        {
            RuleFor(x => x.Amount)
               .NotEmpty().WithMessage("Amount can't be empty");

            RuleFor(x => x.Date)
               .NotEmpty().WithMessage("Date can't be empty");
        }
    }
}
