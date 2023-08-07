using DBAccess.IRepos;
using DBAccess.Models;
using Medical_Rgistrations.IRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBAccess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QualificationsController : ControllerBase
    {

        private readonly ILogger<QualificationsController> _logger;
        private readonly IQualification _repo;

        public QualificationsController(ILogger<QualificationsController> logger,IQualification repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.Get());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,e.Message);
            }
            
        }

        [HttpPost("Add")]
        public IActionResult Put(Qualification model)
        {
            try
            {
                return Ok(_repo.Add(model));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("GetGenders")]
        public IActionResult GetGenders()
        {
            try
            {
                return Ok(_repo.GetGenders());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repo.GetById(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("RemoveById")]
        public IActionResult RemoveById(int id)
        {
            try
            {
                return Ok(_repo.RemoveById(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}