using DBAccess.AppContext;
using DBAccess.Models;
using DBAccess.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DBAccess.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SSOContext _sSOContext;
        private readonly IConfiguration _configuration;

        public AuthenticationController(SSOContext context,IConfiguration configuration)
        {
            _sSOContext = context;
            _configuration = configuration;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] Login user)
        {
           
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var dbUser = _sSOContext.Users.Where(x => x.UserName == user.UserName.Trim() && x.Password == user.Password.Trim()).FirstOrDefault();
            
            if (dbUser is null)
            {
                return NotFound("Invalid user request!!!");
            }


            if (user.UserName == dbUser.UserName && user.Password == dbUser.Password)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT").GetSection("Secret").Value));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(issuer: _configuration.GetSection("JWT").GetSection("ValidIssuer").Value, 
                    audience: _configuration.GetSection("JWT").GetSection("ValidAudience").Value, 
                    claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(10), signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new JWTTokenResponse
                {
                    Token = tokenString
                });
            }
            return Unauthorized();
        }
    }
}
