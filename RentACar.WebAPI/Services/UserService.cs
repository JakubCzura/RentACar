using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Repositories.Interfaces;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Services
{
    public class UserService : CrudService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
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
    }
}