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
      typeof(UserMap)
    };

    /**
    * Automappers
    */

    public static readonly List<SmartMapperMap> SmartMappersList = new List<SmartMapperMap>{
      new SmartMapperMap(typeof(User), typeof(UserDTO))
    };

    public static List<ISmartError> ErrorsList = new List<ISmartError>()
    {
      // qui andranno inseriti tutti gli errori possibili del sistema

      //* FACSIMILE DI ERRORE
      //* new SmartError(404, "TIPO_DI_ERRORE", "Overload del messaggio di errore"),
    };
  }
}