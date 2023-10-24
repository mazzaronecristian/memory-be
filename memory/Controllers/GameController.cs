using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using memory.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using SmartFrame.ASPNETCore;
using SmartFrame.ASPNETCore.Configuration;
using SmartFrame.ASPNETCore.Database;
using SmartFrame.ASPNETCore.JWT;
using memory.Enumerators;
using SmartFrame.ASPNETCore.Error;
using memory.Entities;
using AutoMapper;

namespace memory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController
    {
        private readonly ILogger<GameController> _logger;
        private readonly ISmartDBConnection _dbConnection;
        private readonly IMapper _mapper;
        private readonly ISmartConfiguration _config;
        public GameController(ILogger<GameController> logger, ISmartDBConnection dbConnection, ISmartConfiguration config, IMapper mapper)
        {
            _logger = logger;
            _dbConnection = dbConnection;
            _config = config;
            _mapper = mapper;
        }


        [HttpGet]
        public ApiListResponse<GameDTO> GetList([FromHeader] string authorization)
        {
            try
            {

                authorization = authorization.Replace("Bearer ", "");

                var handler = new JwtSecurityTokenHandler();
                string role = handler.ReadJwtToken(authorization).Claims.First(claim => claim.Type == "role")?.Value;
                int userId = int.Parse(handler.ReadJwtToken(authorization).Claims.First(claim => claim.Type == "ID")?.Value);
                if (role == RoleEnum.ADMIN)
                {
                    IQueryable<Game> games = _dbConnection.GetData<Game>();
                    int gamesCount = games.Count();
                    List<GameDTO> gamesResponse = _mapper.Map<List<GameDTO>>(games.ToList());
                    return new ApiListResponse<GameDTO>(gamesResponse, gamesCount);
                }
                if (role == RoleEnum.PLAYER)
                {
                    IQueryable<Game> games = _dbConnection.GetData<Game>().Where(x => x.relatedUser.id == userId);
                    int gamesCount = games.Count();
                    List<GameDTO> gamesResponse = _mapper.Map<List<GameDTO>>(games.ToList());
                    return new ApiListResponse<GameDTO>(gamesResponse, gamesCount);
                }
                return ApiListResponse<GameDTO>.FromErrorCode("ROLE_NOT_FOUND");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}