using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API60New.Models
{
    public class Account
    {
        [Key]
        public string NIK { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
    }
}
