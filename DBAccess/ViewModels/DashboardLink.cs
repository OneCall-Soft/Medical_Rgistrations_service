namespace DBAccess.ViewModels
{
    public class DashboardLink
    {
        public Guid? Id { get; set; }
        public string Position { get; set; }
        public string TemplateName { get; set; }
        public string Link { get; set; }
        public string LinksName { get; set; }
        public bool Active { get; set; }
    }
}
