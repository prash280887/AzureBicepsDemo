using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAppServiceDemo.Model;

namespace WebAppServiceDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config) { 
         _config = config;
        }

        [HttpGet]
        public IActionResult hello()
        {
            return Ok("Hello");
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult login([FromBody] LoginUserModel loginUserModel)
        {
            if(loginUserModel.username == "admin" && loginUserModel.password == "password")
            {
                var usertoken = GenerateToken(loginUserModel.username);
                JsonContent response = JsonContent.Create(new {status = "success", accesstoken = usertoken });
                return Ok(response);
            }
            else
            { return Unauthorized("Invalid username or password");
            }

        }

        private string GenerateToken(string userIdentifier)
        {
            var securityKey = _config.GetSection("JwtSettings:SecretKey").Value;
            // Generate JWT token logic here
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,userIdentifier),
                    new Claim(ClaimTypes.Role,"Admin")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
              //  Audience = _config.GetSection("JwtSettings:Audience").Value,                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)), SecurityAlgorithms.HmacSha256Signature)
            });

            
            return tokenHandler.WriteToken(token);
        }

    }
}
