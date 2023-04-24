using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RentACar.WebAPI.Models.Dtos;
using RentACar.WebAPI.Services.Interfaces;

namespace RentACar.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<RegisterUserDto> _registerUserDtoValidator;

        public UserController(IUserService userService, IValidator<RegisterUserDto> registerUserDtoValidator)
        {
            _userService = userService;
            _registerUserDtoValidator = registerUserDtoValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            if (users == null)
            {
                return NotFound(users);
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
            {
                NotFound(user);
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUserDto dto)
        {
            ValidationResult validation = await _registerUserDtoValidator.ValidateAsync(dto);
            if (validation.IsValid)
            {
                await _userService.CreateAsync(dto);
                return CreatedAtAction(nameof(Post), new { dto.Name, dto.Surname, dto.Email });
            }
            else
            {
                return BadRequest(dto);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}