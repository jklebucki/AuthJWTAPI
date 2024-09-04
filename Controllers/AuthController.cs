using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthJWTAPI.Commands;
using AuthJWTAPI.Data;
using AuthJWTAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthJWTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterCommand newUser)
        {
            if (UserData.Users.Any(u => u.Username == newUser.Username))
            {
                return BadRequest("User already exists");
            }
            
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = newUser.Username,
                Password = newUser.Password
            };
            var roles = new List<string> { "User" };
            user.Roles = roles;

            user.Id = Guid.NewGuid().ToString();
            UserData.Users.Add(user);
            return Ok();
        }

        [HttpPost("signin")]
        public IActionResult SignIn(SignInCommand login)
        {
            var user = UserData.Users.SingleOrDefault(x => x.Username == login.Username && x.Password == login.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Roles.First())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

        [Authorize]
        [HttpPost("signout")]
        public IActionResult SignOut()
        {
            // Implementacja wylogowania użytkownika
            return Ok();
        }

        [Authorize]
        [HttpPost("changepassword")]
        public IActionResult ChangePassword(string newPassword)
        {
            var username = User.Identity.Name;
            var user = UserData.Users.SingleOrDefault(u => u.Username == username);

            if (user == null)
            {
                return Unauthorized();
            }

            user.Password = newPassword;
            return Ok();
        }

        [HttpPost("forgotpassword")]
        public IActionResult ForgotPassword(string username)
        {
            var user = UserData.Users.SingleOrDefault(u => u.Username == username);

            if (user == null)
            {
                return NotFound("User not found");
            }

            // Implementacja mechanizmu resetowania hasła (np. wysłanie emaila z linkiem do resetu)
            return Ok();
        }

        [HttpPost("resetpassword")]
        public IActionResult ResetPassword(string username, string newPassword)
        {
            var user = UserData.Users.SingleOrDefault(u => u.Username == username);

            if (user == null)
            {
                return NotFound("User not found");
            }

            user.Password = newPassword;
            return Ok();
        }
    }
}
