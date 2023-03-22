using Microsoft.Data.SqlClient;
using System.Data;

namespace Archer.Infrastructure.Output.Factory
{
    public class SqlFactoryOutput
    {
        public IDbConnection SqlConnection()
        {
            return new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=DB_FROTA;Integrated Security=True");
        }
    }
}
