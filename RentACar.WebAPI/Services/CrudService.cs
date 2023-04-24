using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class CrudService<T> : ICrudService<T> where T : class
    {
        private readonly ICrudRepository<T> _crudRepository;

        public CrudService(ICrudRepository<T> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _crudRepository.GetAllAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _crudRepository.GetAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _crudRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _crudRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _crudRepository.DeleteAsync(id);
        }
    }
}