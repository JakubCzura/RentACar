using RentACar.WebAPI.Models;
using RentACar.WebAPI.Models.Dtos;

namespace RentACar.WebAPI.Repositories.Interfaces
{
    public interface IUserRepository : ICrudRepository<User>
    {
        Task<User> GetByEmailAndPasswordAsync(LogInUserDto dto);
    }
}