using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibrarySQLAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]

        public string Title { get; set; }
        [Range(1, 100000)]

        public decimal Price { get; set; }

        [ForeignKey("Category")]

        public int CatId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
