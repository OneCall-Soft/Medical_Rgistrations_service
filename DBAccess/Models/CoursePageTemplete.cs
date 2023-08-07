using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAccess.Models
{
    public class CoursePageTemplete
    {
        public Guid Id { get; set; }
        public string? TemplateName { get; set; }
        public bool Active { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? HtmlContent { get; set; }
        public Guid? GallaryGroupId { get; set; }
        public DateTime? CreatedOn  { get; set; }
        public DateTime? ModifiedOn  { get; set; }
    }
}
