using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class PickupLocationService : CrudService<PickupLocation>, IPickupLocationService
    {
        public PickupLocationService(IPickupLocationRepository pickupLocationRepository) : base(pickupLocationRepository)
        {
        }
    }
}