using Microsoft.AspNetCore.Mvc;
using RentACar.WebAPI.Services;
using RentACar.WebAPI.Services.Interfaces;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDropoffLocation(int id)
        {
            var location = await _dropoffLocationService.GetAsync(id);
            if (location == null)
            {
                NotFound(location);
            }
            return Ok(location);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPickupLocation(int id)
        {
            var location = await _pickupLocationService.GetAsync(id);
            if (location == null)
            {
                NotFound(location);
            }
            return Ok(location);
        }
    }
}