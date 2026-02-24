using System.ComponentModel.DataAnnotations;

namespace Insurance_crud_api.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string PasswordHash { get; set; } = "";

        public Role Role { get; set; } = Role.Customer;
    }
}