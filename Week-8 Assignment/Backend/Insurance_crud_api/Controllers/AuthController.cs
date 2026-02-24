using Microsoft.AspNetCore.Mvc;
using Insurance_crud_api.DTOs;
using Insurance_crud_api.Services.Interfaces;

namespace Insurance_crud_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _authService.UserExistsAsync(dto.Email))
                return BadRequest(new { message = "User already exists" });

            await _authService.RegisterAsync(dto);
            return Ok(new { message = "Registered successfully" });
        }

        // LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _authService.ValidateLoginAsync(dto);
            if (user == null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(new { user.Id, user.Name, user.Email, user.Role });
        }

        // GET ALL USERS (Admin)
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _authService.GetAllUsersAsync();
            return Ok(users);
        }

        // FORGOT PASSWORD — verify email exists
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var exists = await _authService.EmailExistsAsync(dto.Email);
            if (!exists) return NotFound(new { message = "No account found with that email." });
            return Ok(new { message = "Email verified. Please set a new password." });
        }

        // RESET PASSWORD
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var success = await _authService.ResetPasswordAsync(dto.Email, dto.NewPassword);
            if (!success) return NotFound(new { message = "User not found." });
            return Ok(new { message = "Password reset successfully. Please log in." });
        }
    }
}