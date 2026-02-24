using Insurance_crud_api.DTOs;
using Insurance_crud_api.Models;

namespace Insurance_crud_api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> UserExistsAsync(string email);
        Task<User> RegisterAsync(RegisterDto dto);
        Task<User?> ValidateLoginAsync(LoginDto dto);
        Task<IEnumerable<object>> GetAllUsersAsync();
        Task<bool> EmailExistsAsync(string email);
        Task<bool> ResetPasswordAsync(string email, string newPassword);
    }
}
