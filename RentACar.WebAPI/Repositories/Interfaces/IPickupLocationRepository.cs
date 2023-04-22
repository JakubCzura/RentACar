using RentACar.WebAPI.Models;

namespace RentACar.WebAPI.Repositories.Interfaces
{
    public interface IPickupLocationRepository
    {
        Task<IEnumerable<PickupLocation>> GetAllAsync();
        Task<PickupLocation> GetAsync(int id);
        Task CreateAsync(PickupLocation location);
        Task UpdateAsync(PickupLocation location);
        Task DeleteAsync(int id);
    }
}
