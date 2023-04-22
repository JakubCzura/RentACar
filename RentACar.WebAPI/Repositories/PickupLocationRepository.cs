using Microsoft.EntityFrameworkCore;
using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;

namespace RentACar.WebAPI.Repositories
{
    public class PickupLocationRepository : IPickupLocationRepository
    {
        private readonly RentACarDbContext _rentACarDbContext;

        public PickupLocationRepository(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }

        public async Task<IEnumerable<PickupLocation>> GetAllAsync()
        {
            return await _rentACarDbContext.PickupLocation.ToListAsync();
        }

        public async Task<PickupLocation> GetAsync(int id)
        {
            return await _rentACarDbContext.PickupLocation.FindAsync(id) ?? null!;
        }

        public async Task CreateAsync(PickupLocation pickupLocation)
        {
            await _rentACarDbContext.PickupLocation.AddAsync(pickupLocation);
            await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PickupLocation pickupLocation)
        {
            _rentACarDbContext.Update(pickupLocation);
            await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pickupLocation = await _rentACarDbContext.PickupLocation.FindAsync(id);
            _rentACarDbContext.PickupLocation.Remove(pickupLocation!);
            await _rentACarDbContext.SaveChangesAsync();
        }
    }
}
