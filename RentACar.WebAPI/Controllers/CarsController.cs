using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cars = await _carService.GetAllAsync();
            if (cars == null)
            {
                return NotFound(cars);
            }
            return Ok(cars);
        }       
    }
}
