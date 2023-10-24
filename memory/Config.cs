using System;
using System.Collections.Generic;
using memory.ClassMaps;
using memory.DTO;
using memory.Entities;
using SmartFrame.ASPNETCore.Error;
using SmartFrame.ASPNETCore.Mapper;

namespace memory
{
  public static class Config
  {
    /**
    * ClassMaps Database 
    */
    public static readonly List<Type> ClasMaps = new List<Type>{
      typeof(UserMap),
      typeof(DifficultyMap),
      typeof(GameMap)
    };

    /**
    * Automappers
    */

    public static readonly List<SmartMapperMap> SmartMappersList = new List<SmartMapperMap>{
      new SmartMapperMap(typeof(User), typeof(UserDTO)),
      new SmartMapperMap(typeof(UserDTO), typeof(User)),
      new SmartMapperMap(typeof(Difficulty), typeof(DifficultyDTO)),
      new SmartMapperMap(typeof(DifficultyDTO), typeof(Difficulty)),
      new SmartMapperMap(typeof(Game), typeof(GameDTO)),
      new SmartMapperMap(typeof(GameDTO), typeof(Game))
    };

    public static List<ISmartError> ErrorsList = new List<ISmartError>()
    {
      // qui andranno inseriti tutti gli errori possibili del sistema
      new SmartError(-100, "GENERIC_ERROR", "Ops. Qualcosa è andato storto!"),

      new SmartError(-200, "EMAIL_IS_NULL", "Il campo email deve essere compilato"),
      new SmartError(-201, "PASSWORD_IS_NULL", "Il campo password deve essere compilato"),
      new SmartError(-202, "USERNAME_ALREADY_EXISTS", "L'utente esiste già"),

      new SmartError(-300, "LOGIN_USER_OR_PASSWORD_INVALID", "username o password invalidi"),

      new SmartError(-400, "ROLE_NOT_FOUND", "il tuo ruolo utente non esiste"),
      //* FACSIMILE DI ERRORE
      //* new SmartError(404, "TIPO_DI_ERRORE", "Overload del messaggio di errore"),
    };
  }
}