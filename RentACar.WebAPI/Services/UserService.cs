using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<User> GetByEmailAndPasswordAsync(LogInUserDto dto)
        {
            return await _userRepository.GetByEmailAndPasswordAsync(dto);
        }

        public async Task CreateAsync(RegisterUserDto dto)
        {
            User user = new()
            {
                Name = dto.Name,
                Email = dto.Email,
                Surname = dto.Surname,
                Password = PasswordHasher.HashPassword(dto.Password),
                PhoneNumber = dto.PhoneNumber,
            };
            await _userRepository.CreateAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
