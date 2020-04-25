using System;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
namespace portalNews
{
    public class DbOperation
    { 
        private readonly IConfiguration _conf;
        private readonly ILogger<DbOperation> _logger;
        private readonly string mysqlConStr;
        //public MySqlConnection ml { get; }
        public DbOperation(IConfiguration conf, ILogger<DbOperation> logger)
        {
            _logger = logger;
            _conf = conf;
            mysqlConStr = _conf["Dapper:database"];
           

        }

         public MySqlConnection  Connnection
        {
            get
            {

                return new MySqlConnection(mysqlConStr);
            }
        }

    }
}
