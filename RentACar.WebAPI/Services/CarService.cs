using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _carRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Car>> GetAllAvailableAsync()
        {
            IEnumerable<Car> cars = await _carRepository.GetAllAsync();
            return cars.Where(x => x.IsAvailable == true);
        }

        public async Task<Car> GetAsync(int id)
        {
            return await _carRepository.GetAsync(id);
        }

        public async Task UpdateAsync(Car car)
        {
            await _carRepository.UpdateAsync(car);
        }
    }
}
