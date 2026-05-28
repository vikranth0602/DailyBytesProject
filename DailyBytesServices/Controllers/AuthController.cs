using DailyBytesDAL.Models;
using DailyBytesDAL.Repositories.Interfaces;
using DailyBytesServices.DTOs.Auth;
using DailyBytesServices.Helpers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

 
    #region Register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
    {
       
            if (await _userRepository.CheckEmailExistsAsync(dto.Email))
                return BadRequest(new { message = "Email already exists" });

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = dto.Password,
                CreatedDate = DateTime.Now
            };

            var result = await _userRepository.RegisterAsync(user);

            if (!result)
                return StatusCode(500, new { message = "Registration failed" });

            return Ok(
                 new ApiResponse<object>
                 {
                     Success = true,
                     Message = "User registered successfully",
                     Data = null
                 }
            );


    }
    #endregion

  
    #region login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO dto)
    {
            var user = await _userRepository.ValidateUserAsync(dto.Email, dto.Password);

            if (user == null)
                return Unauthorized(
                     new ApiResponse<object>
                     {
                         Success = false,
                         Message = "Invalid credentials",
                         Data = null
                     }
                );

        return Ok(
             new ApiResponse<UserDTO>
             {
                 Success = true,
                 Message = "Login successful",
                 Data = new UserDTO
                 {
                     Id = user.Id,
                     Email = user.Email,
                     FirstName = user.FirstName
                 }
             }

        );

    }
    #endregion

}