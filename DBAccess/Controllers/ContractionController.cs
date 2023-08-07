using DBAccess.IRepos;
using DBAccess.Models;
using Medical_Rgistrations.IRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBAccess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractionController : ControllerBase
    {
        

        private readonly ILogger<ContractionController> _logger;
        private readonly IContraction _repo;

        public ContractionController(ILogger<ContractionController> logger,IContraction repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet("GetAllContraction")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.Get());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return NotFound("No records found");
            }
            
        }

        [HttpPut("AddContraction")]
        public IActionResult Put(Contraction model)
        {
            try
            {
                return Ok(_repo.Add(model));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(new {Error="Unable to register"});               
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
                return NotFound(new { Error = $"Could not found record of id = {id}" });
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
                return NotFound(new { Error = $"Could not found record of id = {id}" });
            }
        }
    }
}