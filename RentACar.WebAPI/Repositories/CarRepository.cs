using Microsoft.EntityFrameworkCore;
using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;

namespace RentACar.WebAPI.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly RentACarDbContext _rentACarDbContext;

        public CarRepository(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _rentACarDbContext.Cars.ToListAsync();
        }

        public async Task<Car> GetAsync(int id)
        {
            return await _rentACarDbContext.Cars.FindAsync(id) ?? null!;
        }

        public async Task CreateAsync(Car car)
        {
            await _rentACarDbContext.Cars.AddAsync(car);
            await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Car car)
        {
            _rentACarDbContext.Cars.Update(car);
            await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var car = await _rentACarDbContext.Cars.FindAsync(id);
            _rentACarDbContext.Cars.Remove(car!);
            await _rentACarDbContext.SaveChangesAsync();
        }
    }
}

