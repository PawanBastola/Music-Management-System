using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperWebApi.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _IConfiguration;
        private readonly string ConnectionString;
        public DapperContext(IConfiguration IConfiguration_)
        {
            _IConfiguration = IConfiguration_;
            ConnectionString = _IConfiguration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(ConnectionString); 

    }
}
