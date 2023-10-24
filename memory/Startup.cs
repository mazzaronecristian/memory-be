using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartFrame.ASPNETCore;
using SmartFrame.ASPNETCore.Database;
using SmartFrame.ASPNETCore.Error;
using SmartFrame.ASPNETCore.JWT;
using SmartFrame.ASPNETCore.Mapper;

namespace memory
{
    public class Startup : SmartStartup
    {

        public override string AppName { get { return "Memory"; } }
        public override string AngularApplicationFolder { get { return "public"; } }
        public override string AppVersion { get { return "1.0.0"; } }

        /**
        * JWT
        */
        public override SmartJWTConfiguration JWTConfiguration => new SmartJWTConfiguration()
        {
            Issuer = Configuration.GetConfiguration("Jwt:Issuer"),
            Audience = Configuration.GetConfiguration("Jwt:Issuer"),
            CryptoKey = Configuration.GetConfiguration("Jwt:Key")
        };

        //TODO: studiare implementazione della crittografia
        /**
         * Crittografia
         */
        // public override SmartEncryptionConfiguration EncryptionConfiguration => new SmartEncryptionConfiguration()
        // {
        //     EncryptionKey = "rD+xU'@@s9$t_a9K", // Chiave di 16 caratteri
        //     EncryptionPassphrase = "t/=\\zKjW~`)2Pnp8" // Chiave di 16 caratteri

        // };
        /**
        * Database
        */
        public override SmartDBConfiguration DBConfiguration => new SmartDBConfiguration()
        {
            ConnectionType = SmartDBConnectionType.MYSQL_INNODB,
            ClassMaps = Config.ClasMaps,
            // la connessione avviene tramite il file appsettings.json (o appsettings.Development.json)
            ConnectionString = Configuration.GetConfiguration("ConnectionStrings:Main"),
            EnableSQLLogging = true
        };

        /**
        * Automapper
        */
        public override List<SmartMapperMap> SmartMappers => Config.SmartMappersList;

        /** 
         * Gestione errori
         */
        public override SmartErrorConfiguration ErrorsConfiguration => new SmartErrorConfiguration()
        {
            DisplayMode = SmartErrorDisplayMode.MESSAGE,
            Errors = Config.ErrorsList
        };

        public Startup(IConfiguration configuration) : base(configuration) { }
    }

}
