using DBAccess.Models;
using DBAccess.ViewModels;
using Medical_Rgistrations.IRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBAccess.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class FacultyController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IFaculty _repo;

        public FacultyController(ILogger<RegistrationController> logger,IFaculty repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [Route("GetFaculties")]
        [HttpGet()]
        public IActionResult GetAllFaculties()
        {
            try
            {
                var data = _repo.GetAllFaculties();
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
        }
        [Route("NewFaculty")]
        [HttpPost()]
        public IActionResult Add(MyFaculty model)
        {
            try
            {                
                return Ok(_repo.SetFaculty(model));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Route("UpdateFaculty")]
        [HttpPost()]
        public IActionResult Update(MyFaculty model)
        {
            try
            {
                return Ok(_repo.UpdateFaculty(model));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Route("GetFacultyById/{id}")]
        [HttpPost()]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_repo.GetFacultyById(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Route("RemoveFacultyById/{id}")]
        [HttpPost()]
        public IActionResult Delete(Guid id)
        {
            try
            {
                return Ok(_repo.RemoveFacultyById(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Route("MassUpdate")]
        [HttpPost()]
        public IActionResult MassUpdate(TemplateActiveUpdate facultyMass)
        {
            try
            {
                return Ok(_repo.UpdateFacultyById(facultyMass));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
    }
}