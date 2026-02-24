using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurance_crud_api.Models
{
    [Table("CrudPolicies")] // ✅ prevent table conflict
    public class Policy
    {
        public int Id { get; set; }

        [Required]
        public string PolicyName { get; set; } = "";

        [Required]
        public string Provider { get; set; } = "";

        public decimal Premium { get; set; }

        public decimal CoverageAmount { get; set; }
    }
}