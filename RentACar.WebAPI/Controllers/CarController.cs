﻿using Microsoft.AspNetCore.Mvc;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await _carService.GetAllAsync();
            if (cars == null)
            {
                return NotFound(cars);
            }
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var car = await _carService.GetAsync(id);
            if (car == null)
            {
                NotFound(car);
            }
            return Ok(car);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllAvailable()
        {
            var cars = await _carService.GetAllAsync();
            if (cars == null)
            {
                return NotFound(cars);
            }
            cars = cars.Where(x => x.IsAvailable == true);
            if (cars.Any())
            {
                return Ok(cars);
            }
            return NotFound(cars);
        }
    }
}