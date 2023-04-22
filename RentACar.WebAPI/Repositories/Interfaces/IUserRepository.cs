using RentACar.WebAPI.Models;
using RentACar.WebAPI.Models.Dtos;

namespace RentACar.WebAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(int id);
        Task<User> GetByEmailAndPasswordAsync(LogInUserDto dto);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
