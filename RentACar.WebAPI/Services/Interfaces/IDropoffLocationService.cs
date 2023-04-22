using RentACar.WebAPI.Models;

namespace RentACar.WebAPI.Services.Interfaces
{
    public interface IDropoffLocationService
    {
        Task<IEnumerable<DropoffLocation>> GetAllAsync();
    }
}
