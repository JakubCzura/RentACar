using Microsoft.EntityFrameworkCore;
using RentACar.WebAPI.Database;
using RentACar.WebAPI.Repositories.Interfaces;

namespace RentACar.WebAPI.Repositories
{
    /// <summary>
    /// Generic class to perform CRUD operations
    /// </summary>
    /// <typeparam name="T">Object to be stored in database</typeparam>
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private readonly RentACarDbContext _rentACarDbContext;
        private readonly DbSet<T> _dbSet;

        public CrudRepository(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
            _dbSet = _rentACarDbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? null!;
        }

        public async Task CreateAsync(T data)
        {
            await _dbSet.AddAsync(data);
            await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T data)
        {
            _dbSet.Update(data);
            await _rentACarDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dbSet.FindAsync(id);
            _dbSet.Remove(data!);
            await _rentACarDbContext.SaveChangesAsync();
        }
    }
}