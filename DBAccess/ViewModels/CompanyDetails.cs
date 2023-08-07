using DBAccess;

namespace DBAccess.ViewModels
{
    public class CompanyDetails
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
