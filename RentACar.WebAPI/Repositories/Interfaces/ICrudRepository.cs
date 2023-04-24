namespace RentACar.WebAPI.Repositories.Interfaces
{
    public interface ICrudRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task CreateAsync(T data);

        Task UpdateAsync(T data);

        Task DeleteAsync(int id);
    }
}