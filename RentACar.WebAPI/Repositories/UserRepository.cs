using Microsoft.EntityFrameworkCore;
using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Repositories.Interfaces;

namespace RentACar.WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RentACarDbContext _rentACarDbContext;

        public UserRepository(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _rentACarDbContext.Users.ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await _rentACarDbContext.Users.FindAsync(id) ?? null!;
        }

        public async Task CreateAsync(User user)
        {
            await _rentACarDbContext.Users.AddAsync(user);
            await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _rentACarDbContext.Update(user);
            await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _rentACarDbContext.Users.FindAsync(id);
            _rentACarDbContext.Users.Remove(user!);
            await _rentACarDbContext.SaveChangesAsync();
        }
    }
}
