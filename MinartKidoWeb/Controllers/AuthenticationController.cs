using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MinartKidoWebDataAccess.Model.Authentication;
using Microsoft.AspNetCore.Http;

namespace MinartKidoWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _config;

        public AuthenticationController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] Login login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user == null) return response;
            var tokenString = BuildToken();
            response = Ok(new {token = tokenString});
            return response;
        }

        private string BuildToken()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "name"),
                new Claim(JwtRegisteredClaimNames.Email, "email"),
                new Claim(JwtRegisteredClaimNames.Birthdate, "birthDate"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Isser"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials:creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserDto Authenticate(Login login)
        {
            UserDto user = null;
            if (login.Username == "admin" && login.Password == "secret")
            {
                user = new UserDto
                {
                    Name = "Bashir",
                    Email = "bashir.mahmoudi@gmail.com"
                };
            }
            return user;
        }
    }
}