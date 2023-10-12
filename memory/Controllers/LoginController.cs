using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartFrame.ASPNETCore;
using SmartFrame.ASPNETCore.Configuration;
using SmartFrame.ASPNETCore.Database;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using memory.DTO;
using memory.Entities;
using System.Linq;
using SmartFrame.ASPNETCore.JWT;
using System.Collections.Generic;

namespace memory.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class LoginController : ControllerBase
  {
    private readonly ILogger<LoginController> _logger;
    private readonly ISmartDBConnection _dbConnection;

    private readonly ISmartConfiguration _config;

    [HttpPost]
    public ApiResponse<string> Login([FromBody] LoginRequestDTO request)
    {
      try
      {
        string username = request.Username;
        string password = request.Password;

        User user = _dbConnection.GetData<User>()
        .FirstOrDefault(x => x.username.ToLower().Equals(username.ToLower()) &&
                            x.password == password);

        if (user == null)
        {
          return ApiResponse<string>.FromErrorCode("LOGIN_USER_OR_PASSWORD_INVALID");
        }

        //TODO: studiare il token jwt e implementarlo a frontend
        string newToken = SmartJWTEngine.GenerateToken(
            _config.GetConfiguration("Jwt:Issuer"),
            _config.GetConfiguration("Jwt:Audience"),
            _config.GetConfiguration("Jwt:Key"),
            /*Constants.MANAGEMENT_TOKEN_DURATION,*/
            60 * 24, //DURATA TOKEN
            null,
            new List<SmartJWTClaim>() {
              new SmartJWTClaim("ID", user.id.ToString())
            }
        );

      }


      catch (System.Exception e)
      {
        _logger.LogError(e.Message);
        throw;
      }
      return new ApiResponse<string>();
    }
  }

}