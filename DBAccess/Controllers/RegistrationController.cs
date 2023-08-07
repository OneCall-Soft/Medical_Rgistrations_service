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
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IRegisterRepo _repo;

        public RegistrationController(ILogger<RegistrationController> logger,IRegisterRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [Route("GetAllRegistrations")]
        [HttpGet()]
        public IActionResult GetAllRegistrations()
        {
            try
            {
                var data = _repo.GetRegistrations();
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
        }
        [Route("NewRgistration")]
        [HttpPost()]
        public IActionResult NewRgistration(RegisterViewModels model)
        {
            try
            {                
                return Ok(_repo.NewRegistration(model));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [Route("GetById/{id}")]
        [HttpPost()]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_repo.GetRegistrationById(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}