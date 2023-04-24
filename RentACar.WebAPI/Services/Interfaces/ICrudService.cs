namespace RentACar.WebAPI.Services.Interfaces
{
    public interface ICrudService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(int id);

        Task CreateAsync(T data);

        Task UpdateAsync(T data);

        Task DeleteAsync(int id);
    }
}