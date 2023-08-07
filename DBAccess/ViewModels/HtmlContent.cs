namespace DBAccess.ViewModels
{
    public class MyHtmlContent
    {

        public Guid Id { get; set; }
        public string HtmlData { get; set; }
        public string TemplateName { get; set; }
        //public Guid? GallaryGroup { get; set; }
        public bool Active { get; set; }
        public string Page { get; set; }
    }
}
