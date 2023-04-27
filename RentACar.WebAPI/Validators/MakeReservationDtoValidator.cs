using FluentValidation;
using RentACar.WebAPI.Models.Dtos;

namespace RentACar.WebAPI.Validators
{
    public class MakeReservationDtoValidator : AbstractValidator<MakeReservationDto>
    {
        public MakeReservationDtoValidator()
        {
            RuleFor(x => x.StartDate)
               .NotEmpty().WithMessage("Start date can't be empty")
               .NotEqual(x => x.EndDate).WithMessage("Start date can't equal end date")
               .GreaterThanOrEqualTo(DateTime.Today);

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date can't be empty")
                .GreaterThan(DateTime.Today);

            RuleFor(x => x.PickupLocationId)
                .NotEmpty().WithMessage("Pickup location is required")
                .GreaterThan(0).WithMessage("Pickup location is required");

            RuleFor(x => x.DropoffLocationId)
               .NotEmpty().WithMessage("Pickup location is required")
               .GreaterThan(0).WithMessage("Pickup location is required");

            RuleFor(x => x.DropoffLocationId)
              .NotEmpty().WithMessage("Pickup location is required")
              .GreaterThan(0).WithMessage("Pickup location is required");

            RuleFor(x => x.UserId)
              .NotEmpty().WithMessage("User is required")
              .GreaterThan(0).WithMessage("User is required");
        }
    }
}