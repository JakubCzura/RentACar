using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<LogInUserDto> _logInUserDtoValidator;

        public LoginController(IUserService userService, IValidator<LogInUserDto> logInUserDtoValidator)
        {
            _userService = userService;
            _logInUserDtoValidator = logInUserDtoValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogInUserDto dto)
        {
            ValidationResult validation = await _logInUserDtoValidator.ValidateAsync(dto);
            if (validation.IsValid)
            {
                User user = await _userService.GetByEmailAndPasswordAsync(dto);
                if (user != null)
                {
                    LoggedUser.Id = user.Id;
                    return Ok(new { userId = user.Id });
                }
            }
            return BadRequest(new { errors = validation.Errors.SelectMany(v => v.ErrorMessage) });
        }
    }
}