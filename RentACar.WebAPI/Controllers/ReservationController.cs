using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
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

        public ReservationController(IValidator<MakeReservationDto> makeReservationDtoValidator, IReservationService reservationService)
        {
            _makeReservationDtoValidator = makeReservationDtoValidator;
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MakeReservationDto makeReservationDto)
        {
            ValidationResult validation = await _makeReservationDtoValidator.ValidateAsync(makeReservationDto);
            if (validation.IsValid)
            {
                await _reservationService.CreateAsync(makeReservationDto);
                return CreatedAtAction(nameof(Create), new { makeReservationDto.StartDate, makeReservationDto.EndDate });
            }
            else
            {
                return BadRequest("Can't make a reservation, invalid data");
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetSummary([FromBody] MakeReservationDto makeReservationDto)
        {
            ValidationResult validation = await _makeReservationDtoValidator.ValidateAsync(makeReservationDto);
            if (validation.IsValid)
            {
                await _reservationService.CreateAsync(makeReservationDto);
                return CreatedAtAction(nameof(Create), new { makeReservationDto.StartDate, makeReservationDto.EndDate });
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
