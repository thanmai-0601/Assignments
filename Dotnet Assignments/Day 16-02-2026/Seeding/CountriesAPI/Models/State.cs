using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CountriesAPI.Models
{
    [Table("States")]
    public class State
    {
        [Key]
        public int SId { get; set; }

        [Required]
        [MaxLength(50)]
        public string SName { get; set; }

        public int CntryId { get; set; }//Foreign Key

        //Navigation Properties
        [JsonIgnore]
        public Country Country { get; set; }
    }
}
