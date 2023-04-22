using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Services.Interfaces;
using RentACar.WebAPI.Services;

namespace RentACar.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IPickupLocationService _pickupLocationService;
        private readonly IDropoffLocationService _dropoffLocationService;

        public LocationController(IPickupLocationService pickupLocationService, IDropoffLocationService dropoffLocationService)
        {
            _pickupLocationService = pickupLocationService;
            _dropoffLocationService = dropoffLocationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPickupLocations()
        {
            var locations = await _pickupLocationService.GetAllAsync();
            if (locations == null)
            {
                return NotFound(locations);
            }
            return Ok(locations);
        }

        [HttpGet]
        public async Task<IActionResult> GetDropoffLocations()
        {
            var locations = await _dropoffLocationService.GetAllAsync();
            if (locations == null)
            {
                return NotFound(locations);
            }
            return Ok(locations);
        }
    }
}
