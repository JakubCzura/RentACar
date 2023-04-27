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
        private readonly IUserService _userService;

        public ReservationController(IValidator<MakeReservationDto> makeReservationDtoValidator, IReservationService reservationService, ICarService carService, IUserService userService)
        {
            _makeReservationDtoValidator = makeReservationDtoValidator;
            _reservationService = reservationService;
            _carService = carService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MakeReservationDto makeReservationDto)
        {
            ValidationResult validation = await _makeReservationDtoValidator.ValidateAsync(makeReservationDto);
            if (validation.IsValid)
            {
                await _reservationService.CreateAsync(makeReservationDto);
                return CreatedAtAction(nameof(Create), new { makeReservationDto.CarId });
            }
            else
            {
                return BadRequest("Can't make a reservation, invalid data");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSummary([FromBody] MakeReservationDto makeReservationDto)
        {
            ValidationResult validation = await _makeReservationDtoValidator.ValidateAsync(makeReservationDto);
            if (validation.IsValid)
            {
                Car car = await _carService.GetAsync(makeReservationDto.CarId);
                User user = await _userService.GetAsync(makeReservationDto.UserId);
                decimal totalCost = TotalCostCalculation.Calculate(makeReservationDto.StartDate, makeReservationDto.EndDate, car.DailyRate);
                return CreatedAtAction(nameof(Create), new
                {
                    makeReservationDto.StartDate,
                    makeReservationDto.EndDate,
                    makeReservationDto.CarId,
                    makeReservationDto.PickupLocationId,
                    makeReservationDto.DropoffLocationId,
                    totalCost,
                    user.Name,
                    user.Surname,
                    user.Email,
                    user.PhoneNumber
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