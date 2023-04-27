using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RentACar.WebAPI.Helper;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly IValidator<MakeReservationDto> _makeReservationDtoValidator;
        private readonly IReservationService _reservationService;
        private readonly ICarService _carService;

        public ReservationController(IValidator<MakeReservationDto> makeReservationDtoValidator, IReservationService reservationService, ICarService carService)
        {
            _makeReservationDtoValidator = makeReservationDtoValidator;
            _reservationService = reservationService;
            _carService = carService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MakeReservationDto makeReservationDto)
        {
            ValidationResult validation = await _makeReservationDtoValidator.ValidateAsync(makeReservationDto);
            if (validation.IsValid)
            {
                await _reservationService.CreateAsync(makeReservationDto);
                Car car = await _carService.GetAsync(makeReservationDto.CarId);
                decimal totalCost = TotalCostCalculation.Calculate(makeReservationDto.StartDate, makeReservationDto.EndDate, car.DailyRate);
                return CreatedAtAction(nameof(Create), new
                {
                    makeReservationDto.StartDate,
                    makeReservationDto.EndDate,
                    makeReservationDto.CarId,
                    makeReservationDto.PickupLocationId,
                    makeReservationDto.DropoffLocationId,
                    totalCost
                });
            }
            else
            {
                return BadRequest("Can't make a reservation, invalid data");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var reservation = await _reservationService.GetAsync(id);
            return Ok(reservation);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservations = await _reservationService.GetAllAsync();
            return Ok(reservations);
        }
    }
}