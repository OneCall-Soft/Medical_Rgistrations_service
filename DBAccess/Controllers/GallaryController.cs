using DBAccess.AppContext;
using DBAccess.IRepos;
using DBAccess.ViewModels;
using Medical_Rgistrations.IRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DBAccess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GallaryController : Controller
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IGallary _repo;

        public GallaryController(ILogger<RegistrationController> logger, IGallary repo)
        {
            _logger = logger;
            _repo = repo;   
        }

        [Route("GetImagesByGroup/{GroupName}")]
        [HttpPost]
        public IActionResult GetImagesByGroup(string groupName)
        {
            try
            {
                return Ok(_repo.GetGallaryPhotos(groupName));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,e.Message);                                
            }
        }

        [Route("SetImagesByGroup")]
        [HttpPost]
        public IActionResult SetImagesByGroup(GallaryViewModel model)
        {
            try
            {
                return Ok(_repo.SetGallaryPhotos(model));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [Route("GetImagesGroups")]
        [HttpGet]
        public IActionResult GetImagesGroups()
        {
            string[] groups = { "Contact","About","Course","Faculty","Home" };

            return Ok(groups);
        }

    }
}
