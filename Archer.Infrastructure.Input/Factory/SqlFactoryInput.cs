using Microsoft.Data.SqlClient;
using System.Data;

namespace Archer.Infrastructure.Input.Factory
{
    public class SqlFactoryInput
    {
        public IDbConnection SqlConnection()
        {
            return new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=DB_FROTA;Integrated Security=True");
        }
    }
}
