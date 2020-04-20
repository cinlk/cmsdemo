using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
namespace news
{
    public class DbOperation
    { 
        private readonly IConfiguration _conf;
        private readonly ILogger<DbOperation> _logger;
        public MySqlConnection ml { get; }
        public DbOperation(IConfiguration conf, ILogger<DbOperation> logger)
        {
            _logger = logger;
            _conf = conf;
            var constr = _conf["Dapper:database"];
           // _logger.LogInformation("mysql ----> {constr}", constr);

            ml = new MySqlConnection(constr);

            //ml.Open();

        }


        
    }
}
