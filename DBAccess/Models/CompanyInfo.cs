using System.ComponentModel.DataAnnotations;

namespace DBAccess.Models
{
    public class CompanyInfo
    {
        [Key]
        public Guid CompId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? CreatedOn { get; set; }
        public string? ModifiedOn { get; set; }
    }
}
