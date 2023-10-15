using System;
using AutoMapper;
using memory.DTO;
using memory.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate;
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

    [HttpPost]
    public ApiResponse<UserDTO> Create([FromBody] UserDTO value)
    {
      try
      {
        using (ITransaction transaction = _dbConnection.OpenTransaction())
        {
          try
          {
            User newItem = _mapper.Map<User>(value);

            if (!string.IsNullOrWhiteSpace(newItem.username))
            {
              newItem.username = newItem.username.ToUpper();
            }
            _dbConnection.SaveData<User>(newItem);

            //gestione degli errori
            if (string.IsNullOrWhiteSpace(newItem.email))
            {
              transaction.Rollback();
              return ApiResponse<UserDTO>.FromErrorCode("EMAIL_IS_NULL");
            }
            if (string.IsNullOrWhiteSpace(newItem.password))
            {
              transaction.Rollback();
              return ApiResponse<UserDTO>.FromErrorCode("PASSWORD_IS_NULL");
            }


            UserDTO itemResponse = _mapper.Map<UserDTO>(newItem);
            transaction.Commit();
            return new ApiResponse<UserDTO>(itemResponse);
          }
          catch (NHibernate.Exceptions.GenericADOException e)
          {
            if (e.HResult == -2146233088)
            {
              return ApiResponse<UserDTO>.FromErrorCode("USERNAME_ALREADY_EXISTS");
            }
            transaction.Rollback();
            throw;
          }
        }
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        throw;
      }
    }
  }
}