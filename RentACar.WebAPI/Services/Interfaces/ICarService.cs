using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Models;

namespace RentACar.WebAPI.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<IEnumerable<Car>> GetAllAvailableAsync();
        Task<Car> GetAsync(int id);
        Task UpdateAsync(Car car);
    }
}
