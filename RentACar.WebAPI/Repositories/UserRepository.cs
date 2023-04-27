using Microsoft.EntityFrameworkCore;
using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Repositories.Interfaces;

namespace RentACar.WebAPI.Repositories
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        private readonly RentACarDbContext _rentACarDbContext;

        public UserRepository(RentACarDbContext rentACarDbContext) : base(rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }

        /// <summary>
        /// Function to authenticate user by emaiil and password
        /// </summary>
        /// <param name="dto">Dto model to log in user</param>
        /// <returns>User instance if user is logged in, otherwise null</returns>
        public async Task<User> GetByEmailAndPasswordAsync(LogInUserDto dto)
        {
            var user = await _rentACarDbContext.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (user == null)
            {
                return null!;
            }
            return PasswordHasher.VerifyPassword(dto.Password, user!.Password) ? user : null!;
        }
    }
}