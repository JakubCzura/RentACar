﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RentACar.WebAPI.Models.Dtos;
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

        [HttpGet]
        [Route("/[action]")]
        public async Task<IActionResult> GetAllAvailable()
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
