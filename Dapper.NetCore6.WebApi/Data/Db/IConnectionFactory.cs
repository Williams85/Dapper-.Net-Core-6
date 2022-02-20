using System.Data;

namespace Dapper.NetCore6.WebApi.Data.Db
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
