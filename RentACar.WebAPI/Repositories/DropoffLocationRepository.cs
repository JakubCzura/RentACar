using Microsoft.EntityFrameworkCore;
using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;

namespace RentACar.WebAPI.Repositories
{
    public class DropoffLocationRepository : IDropoffLocationRepository
    {
        private readonly RentACarDbContext _rentACarDbContext;

        public DropoffLocationRepository(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }

        public async Task<IEnumerable<DropoffLocation>> GetAllAsync()
        {
            return await _rentACarDbContext.DropoffLocations.ToListAsync();
        }

        public async Task<DropoffLocation> GetAsync(int id)
        {
            return await _rentACarDbContext.DropoffLocations.FindAsync(id) ?? null!;
        }

        public async Task CreateAsync(DropoffLocation dropoffLocation)
        {
            await _rentACarDbContext.DropoffLocations.AddAsync(dropoffLocation);
            await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(DropoffLocation dropoffLocation)
        {
            _rentACarDbContext.Update(dropoffLocation);
            await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dropoffLocation = await _rentACarDbContext.DropoffLocations.FindAsync(id);
            _rentACarDbContext.DropoffLocations.Remove(dropoffLocation!);
            await _rentACarDbContext.SaveChangesAsync();
        }
    }
}
