using System.ComponentModel.DataAnnotations;

namespace DBAccess.Models
{
    public class Genders
    {
        [Key]
        public int Id { get; set; }
        public string? Value { get; set; }

        public virtual ICollection<SSORegistrations>? Registrations { get; set; }

    }
}
