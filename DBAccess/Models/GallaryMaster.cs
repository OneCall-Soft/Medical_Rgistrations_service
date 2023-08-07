using System.ComponentModel.DataAnnotations;

namespace DBAccess.Models
{
    public class Gallary
    {
        public Gallary()
        {

        }

        [Key]
        public Guid Id { get; set; }
        //public Guid? GroupId { get; set; }
        public string GroupName { get; set; }
        public string FileName { get; set; }
        public int? order { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Active { get; set; }

    }
}
