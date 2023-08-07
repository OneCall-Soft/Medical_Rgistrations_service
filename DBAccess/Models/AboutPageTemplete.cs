using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAccess.Models
{
    public class PageTemplete
    {
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? HtmlContent { get; set; }
        public string? TemplateName { get; set; }
        public string Page { get; set; }
        public bool Active { get; set; }
        //public Guid? GallaryGroupId  { get; set; }
        public DateTime? CreatedOn  { get; set; }
        public DateTime? ModifiedOn  { get; set; }
    }
}
