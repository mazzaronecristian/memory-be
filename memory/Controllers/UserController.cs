using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartFrame.ASPNETCore;
using SmartFrame.ASPNETCore.Configuration;
using SmartFrame.ASPNETCore.Database;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace memory.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController
  {

    private readonly ILogger<LoginController> _logger;
    private readonly ISmartDBConnection _dbConnection;

    private readonly IMapper _mapper;
    private readonly ISmartConfiguration _config;

    public UserController(ILogger<LoginController> logger, ISmartDBConnection dbConnection, IMapper mapper, ISmartConfiguration config)
    {
      _logger = logger;
      _dbConnection = dbConnection;
      _mapper = mapper;
      _config = config;
    }

  }
}