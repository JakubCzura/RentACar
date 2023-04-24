using RentACar.WebAPI.Models;
using RentACar.WebAPI.Models.Dtos;

namespace RentACar.WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetAsync(int id);

        Task<User> GetByEmailAndPasswordAsync(LogInUserDto dto);

        Task CreateAsync(RegisterUserDto dto);

        Task UpdateAsync(User user);

        Task DeleteAsync(int id);
    }
}