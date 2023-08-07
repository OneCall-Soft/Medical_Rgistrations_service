namespace DBAccess.ViewModels
{
    public class GallaryViewModel
    {
        public Guid? Id { get; set; }
        //public Guid? GroupId { get; set; }
        public string GroupName { get; set; }
        public string FileName { get; set; }
        public int? order { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Active { get; set; }
    }
}
