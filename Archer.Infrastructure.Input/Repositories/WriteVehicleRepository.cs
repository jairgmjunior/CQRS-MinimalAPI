using Archer.Application.Input.Repositories;
using Archer.Domain.Entities;
using Archer.Infrastructure.Input.Factory;
using Archer.Infrastructure.Input.Queries;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Infrastructure.Input.Repositories
{
    public class WriteVehicleRepository : IWriteVehicleRepository
    {
        private readonly IDbConnection _connection;

        public WriteVehicleRepository(SqlFactoryInput factory)
        {
            _connection = factory.SqlConnection();
        }

        public void InsertVehicle(VehicleEntity vehicle)
        {
            var query = new VehicleQuery().InsertVehicleQuery(vehicle);

            try
            {
                using (_connection)
                {
                    _connection.Execute(query.Query, query.Parameters);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao Inserir veiculo");
            }
        }
    }
}
