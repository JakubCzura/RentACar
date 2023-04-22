using RentACar.WebAPI.Models;

namespace RentACar.WebAPI.Services.Interfaces
{
    public interface IPickupLocationService
    {
        Task<IEnumerable<PickupLocation>> GetAllAsync();
    }
}
