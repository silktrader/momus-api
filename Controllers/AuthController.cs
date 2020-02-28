using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Momus.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;

namespace Momus.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly AuthSettings _authSettings;

    public AuthController(IOptions<AuthSettings> authSettings)
    {
      _authSettings = authSettings.Value;
    }

    [HttpPost("login")]
    public IActionResult Login(User user)
    {
      if (user.Password != _authSettings.AdminPassword)
        return Unauthorized("Invalid administrator password");

      var tokenHandler = new JwtSecurityTokenHandler();
      var secret = Encoding.ASCII.GetBytes(_authSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Expires = DateTime.Now.AddDays(10),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha512Signature)
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