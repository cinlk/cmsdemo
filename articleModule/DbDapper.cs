using System;
using Dapper;
using Microsoft.Extensions.Logging;

using MySql.Data.MySqlClient;
using articleModule.Models;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
namespace articleModule
{
    public class DbDapper
    {

        private readonly IConfiguration _conf;
        private readonly ILogger<DbDapper> _logger;
        public  MySqlConnection ml { get;  }
        public DbDapper(IConfiguration conf, ILogger<DbDapper> logger)
        {
            _logger = logger;
            _conf = conf;
            var constr = _conf["Dapper:database"];
            _logger.LogInformation("mysql ----> {constr}", constr);

            ml = new MySqlConnection(constr);
            
            //ml.Open();
            
        }

        //public MySqlConnection getConnet (string type = "mysql")
        //{

        //    // default
        //    return ml;
        //}
         


    }
}
