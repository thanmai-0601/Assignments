using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CountriesAPI.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int CId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CName { get; set; }

        [MaxLength(10)]
        public string CCode { get; set; }

        //Navigation Property
        [JsonIgnore]
     
        public ICollection<State> States { get; set; }

    }
}
