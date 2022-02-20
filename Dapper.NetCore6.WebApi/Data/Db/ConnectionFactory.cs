using System.Data;
using System.Data.SqlClient;

namespace Dapper.NetCore6.WebApi.Data.Db
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection GetConnection
        {
            get
            {
                var cn = new SqlConnection(_configuration.GetConnectionString("CnDapper"));
                if (cn == null) return null;
                cn.Open();
                return cn;
            }
        }
    }
}
