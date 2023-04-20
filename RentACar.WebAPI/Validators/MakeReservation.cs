using FluentValidation;
using RentACar.WebAPI.Models.Dtos;

namespace RentACar.WebAPI.Validators
{
    public class MakeReservation : AbstractValidator<MakeReservationDto>
    {
        public MakeReservation()
        {
            RuleFor(x => x.StartDate)
               .NotEmpty().WithMessage("Start date can't be empty");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date can't be empty");


            RuleFor(x => x.TotalCost)
                .NotEmpty().WithMessage("Total cost can't be empty")
                .GreaterThan(0).WithMessage("Total cost must be greater than 0");
        }
    }
}
