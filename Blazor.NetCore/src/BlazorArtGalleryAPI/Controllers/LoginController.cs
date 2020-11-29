using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BlazorArtGallery.Model;
using BlazorArtGalleryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;

namespace BlazorArtGalleryAPI.Controllers
{
  [Route("api/[controller]")]
  public class LoginController : ControllerBase
  {
    private readonly IUserRepository _UserRepository;
    private readonly JWTSettings _jwtsettings;

    //public IActionResult Index()
    //{
    //  return View();
    //}

    public LoginController(IUserRepository userRepository, IOptions<JWTSettings> jwtsettings)
    {
      _UserRepository = userRepository;
      _jwtsettings = jwtsettings.Value;
    }

    // POST: api/Login
    [HttpPost()]
    public async Task<ActionResult<UserWithToken>> Login([FromBody] User user)
    {
      //dbUser = await _context.Users.Include(u => u.Role)
      //  .Where(u => u.EmailAddress == dbUser.EmailAddress
      //              && u.Password == dbUser.Password).FirstOrDefaultAsync();

      try
      {
        var dbUser = await _UserRepository.GetUserAsync(user.UserId);

        if (dbUser != null)
        {
          RefreshToken refreshToken = GenerateRefreshToken();
          dbUser.RefreshTokens.Add(refreshToken);
          await _UserRepository.SaveUserAsync(dbUser);

          var userWithToken = new UserWithToken(dbUser);
          userWithToken.RefreshToken = refreshToken.Token;


          //sign your token here here..
          userWithToken.AccessToken = GenerateAccessToken(dbUser.UserId);
          return userWithToken;
        }

      }
      catch (Exception ex)
      {
        var x = ex;
        throw new Exception($@"User {user.FirstName} not found");
      }
      return null;

    }

    #region Private Methods

    private RefreshToken GenerateRefreshToken()
    {
      RefreshToken refreshToken = new RefreshToken();

      var randomNumber = new byte[32];
      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(randomNumber);
        refreshToken.Token = Convert.ToBase64String(randomNumber);
      }
      refreshToken.ExpiryDate = DateTime.UtcNow.AddMonths(6);

      return refreshToken;
    }

    private string GenerateAccessToken(int userId)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, Convert.ToString(userId))
        }),
        Expires = DateTime.UtcNow.AddDays(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
          SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }


    #endregion
  }
}
