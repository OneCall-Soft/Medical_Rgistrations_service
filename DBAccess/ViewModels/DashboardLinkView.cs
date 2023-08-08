namespace DBAccess.ViewModels
{
    public class DashboardLinkView
    {
        public DashboardLinkView()
        {
            this.FooterLink1 = new List<AncorLink>();
            this.NotificationLink = new List<AncorLink>();
            this.DownloadLink = new List<AncorLink>();
            this.FooterLink2 = new List<AncorLink>();
        }
        public List<AncorLink> NotificationLink { get; set; }
        public List<AncorLink> DownloadLink { get; set; }
        public List<AncorLink> FooterLink1 { get; set; }
        public List<AncorLink> FooterLink2 { get; set; }
    }


    public class AncorLink
    {
        public string Name { get; set; }
        public string link { get; set; }
    }
    public class AncorLinks
    {
        public string link { get; set; }
    }
}
