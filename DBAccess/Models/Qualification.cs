using System.ComponentModel.DataAnnotations;

namespace DBAccess.Models
{
    public class Qualification
    {
        [Key]
        public int Id { get; set; }
        public string? Value { get; set; }

        public virtual ICollection<SSORegistrations>? Registrations { get; set; }
    }
}
