namespace DBAccess.ViewModels
{
    public class MyFaculty
    {
        public Guid? FacultyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string ProfileName { get; set; }

        public string InstituteName { get; set; }
        public bool Active { get; set; }
    }
}
