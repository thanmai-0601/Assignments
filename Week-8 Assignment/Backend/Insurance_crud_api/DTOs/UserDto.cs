using Insurance_crud_api.Models;

namespace Insurance_crud_api.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public Role Role { get; set; }
    }
}