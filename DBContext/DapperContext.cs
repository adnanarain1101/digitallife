using MySql.Data.MySqlClient;
using System.Data;

namespace Store_Dashboard.DBContext
{
    public class DapperContext : IDapperContext
    {
        IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection ConnectionCreate()
        {
            return new MySqlConnection(_configuration.GetConnectionString("DefaultConnectionString"));
        }
    }
}
