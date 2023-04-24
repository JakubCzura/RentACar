using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Models;

namespace RentACar.WebAPI.Services.Interfaces
{
    public interface ICarService : ICrudService<Car>
    {
        Task<IEnumerable<Car>> GetAllAvailableAsync();
    }
}
