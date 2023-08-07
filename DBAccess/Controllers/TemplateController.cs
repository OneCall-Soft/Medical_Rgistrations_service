using DBAccess.ViewModels;
using Medical_Rgistrations.IRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DBAccess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TemplateController : Controller
    {

        private readonly ILogger<TemplateController> _logger;
        private readonly IAdminTemplates _repo;

        public TemplateController(ILogger<TemplateController> logger, IAdminTemplates repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [Route("SetTemplate")]
        [HttpPost]
        public IActionResult SetTemplate(MyHtmlContent htmlContent)
        {
            try
            {
                var inserted = _repo.SetTemplate(htmlContent);

                if (inserted.Success)
                {
                    return NoContent();
                }

                return Ok(inserted);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [Route("GetTemplates")]
        [HttpPost]
        public IActionResult GetTemplates(string page)
        {
            try
            {
                var templates = _repo.GetTemplate(page);

                if (templates.Data == null && templates.Success)
                {
                    return NoContent();
                }

                if (templates.Data == null && !templates.Success)
                {
                    return BadRequest(templates.Message);
                }

                return Ok(templates);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Route("UpdateTemplate")]
        [HttpPost]
        public IActionResult UpdateTemplate(MyHtmlContent htmlContent)
        {
            try
            {
                var updatedTemplate = _repo.UpdateTemplate(htmlContent);

                if (updatedTemplate.Data == null)
                {
                    return NotFound(updatedTemplate.Message);
                }

                return Ok(updatedTemplate);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Route("GetActiveTemplate")]
        [HttpPost]
        public IActionResult GetAboutActiveTemplate(string pageName)
        {
            try
            {
                var template = _repo.GetActiveTemplate(pageName);

                if (template.Data == null)
                {
                    return NotFound(template.Message);
                }
                return Ok(_repo.GetActiveTemplate(pageName));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


    }
}
