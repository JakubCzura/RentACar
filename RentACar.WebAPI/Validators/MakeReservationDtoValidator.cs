using FluentValidation;
using RentACar.WebAPI.Models.Dtos;

namespace RentACar.WebAPI.Validators
{
    public class MakeReservationDtoValidator : AbstractValidator<MakeReservationDto>
    {
        public MakeReservationDtoValidator()
        {
            RuleFor(x => x.StartDate)
               .NotEmpty().WithMessage("Start date can't be empty");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date can't be empty");         
        }
    }
}
