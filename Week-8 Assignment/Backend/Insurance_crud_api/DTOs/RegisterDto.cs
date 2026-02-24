using Insurance_crud_api.Models;

namespace Insurance_crud_api.DTOs
{
    public class RegisterDto
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public Role Role { get; set; } = Role.Customer;
    }
}