using DBAccess.AppContext;
using DBAccess.ViewModels;
using Medical_Rgistrations.IRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBAccess.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ICompany _company;

        public CompanyController(IConfiguration configuration, ICompany company)
        {
            _configuration = configuration;
            _company = company;
        }

        [Route("GetCompany")]
        [HttpGet]
        public IActionResult Details()
        {
            return Ok(_company.GetCompany());
        }

        [Route("AddCompany")]
        [HttpPost]
        public ActionResult Create(CompanyDetails company)
        {
            return Ok(_company.PutCompany(company));
        }
    }
}
