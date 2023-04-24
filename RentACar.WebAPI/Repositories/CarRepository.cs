using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;

namespace RentACar.WebAPI.Repositories
{
    public class CarRepository : CrudRepository<Car>, ICarRepository
    {
        public CarRepository(RentACarDbContext rentACarDbContext) : base(rentACarDbContext)
        {
        }
    }
}