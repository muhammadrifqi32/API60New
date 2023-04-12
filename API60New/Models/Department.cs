using System.Text.Json.Serialization;

namespace API60New.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
