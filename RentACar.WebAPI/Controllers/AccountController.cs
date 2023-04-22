using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RentACar.WebAPI.Database;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Models;
using RentACar.WebAPI.Services.Interfaces;
using FluentValidation.Results;
using RentACar.WebAPI.Validators;

namespace RentACar.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<LogInUserDto> _logInUserDtoValidator;
        private readonly IValidator<RegisterUserDto> _registerUserDtoValidator;

        public AccountController(IUserService userService, IValidator<LogInUserDto> logInUserDtoValidator, IValidator<RegisterUserDto> registerUserDtoValidator)
        {
            _userService = userService;
            _logInUserDtoValidator = logInUserDtoValidator;
            _registerUserDtoValidator = registerUserDtoValidator;
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
            return BadRequest("Can't log in, invalid credential");
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            ValidationResult validation = await _registerUserDtoValidator.ValidateAsync(dto);
            if (validation.IsValid)
            {
                await _userService.CreateAsync(dto);
                return CreatedAtAction(nameof(Register), new { dto.Name, dto.Surname, dto.Email });
            }
            else
            {
                return BadRequest("Can't register, invalid credential");
            }
        }
    }
}
