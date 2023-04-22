using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class DropoffLocationService : IDropoffLocationService
    {
        private readonly IDropoffLocationRepository _dropoffLocationRepository;

        public DropoffLocationService(IDropoffLocationRepository dropoffLocationRepository)
        {
            _dropoffLocationRepository = dropoffLocationRepository;
        }
        public async Task<IEnumerable<DropoffLocation>> GetAllAsync()
        {
            return await _dropoffLocationRepository.GetAllAsync();
        }
    }
}
