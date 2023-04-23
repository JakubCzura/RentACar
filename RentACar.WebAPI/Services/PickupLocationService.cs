using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class PickupLocationService : IPickupLocationService
    {
        private readonly IPickupLocationRepository _pickupLocationRepository;

        public PickupLocationService(IPickupLocationRepository pickupLocationRepository)
        {
            _pickupLocationRepository = pickupLocationRepository;
        }
        public async Task<IEnumerable<PickupLocation>> GetAllAsync()
        {
            return await _pickupLocationRepository.GetAllAsync();
        }

        public async Task<PickupLocation> GetAsync(int id)
        {
            return await _pickupLocationRepository.GetAsync(id);
        }
    }
}
