using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Momus.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace Momus.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    [HttpPost("login")]
    public IActionResult Login(User user)
    {
      if (user.Password != "replacepassword")
        return Unauthorized("Invalid user name or password");

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = System.Text.Encoding.ASCII.GetBytes("16charactersrequired"); // change me
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Expires = System.DateTime.Now.AddDays(10),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);
      var tokenString = tokenHandler.WriteToken(token);

      return Ok(new
      {
        token = tokenString
      });
    }
  }
}