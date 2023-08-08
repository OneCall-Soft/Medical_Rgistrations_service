using System.ComponentModel.DataAnnotations;

namespace DBAccess.Models
{
    public class DashboardLink
    {
        [Key]
        public Guid Id { get; set; }
        public string Position { get; set; }
        public string TemplateName { get; set; }
        public string Link { get; set; }
        public string LinkName { get; set; }
        public bool Active { get; set; }
    }
}
