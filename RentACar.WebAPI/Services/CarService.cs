using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class CarService : CrudService<Car>, ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository) : base(carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<Car>> GetAllAvailableAsync()
        {
            IEnumerable<Car> cars = await _carRepository.GetAllAsync();
            return cars.Where(x => x.IsAvailable == true);
        }
    }
}