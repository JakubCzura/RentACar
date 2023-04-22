using RentACar.WebAPI.Models;

namespace RentACar.WebAPI.Repositories.Interfaces
{
    public interface IDropoffLocationRepository
    {
        Task<IEnumerable<DropoffLocation>> GetAllAsync();
        Task<DropoffLocation> GetAsync(int id);
        Task CreateAsync(DropoffLocation location);
        Task UpdateAsync(DropoffLocation location);
        Task DeleteAsync(int id);
    }
}
