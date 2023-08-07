using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAccess.Models
{
    public class UserInfo
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
