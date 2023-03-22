using Archer.Application.Output.Dtos;
using Archer.Application.Output.Interfaces;
using Archer.Infrastructure.Output.Factory;
using Archer.Infrastructure.Output.Queries;
using Dapper;
using System.Data;

namespace Archer.Infrastructure.Output.Repositories
{
    public class ReadVehicleRepository : IReadVehicleRepository
    {
        private readonly IDbConnection _connection;

        public ReadVehicleRepository(SqlFactoryOutput factory)
        {
            _connection = factory.SqlConnection();
        }

        public IEnumerable<VehicleDto> FindByCategoryId(int categoryId)
        {
            var query = new VehicleQueries().GetVehicleByCategory(categoryId);

            try
            {
                using (_connection)
                {
                    return _connection.Query<VehicleDto>(query.Query, query.Parameters) as List<VehicleDto>;
                }
            }
            catch (Exception)
            {
                throw new Exception("Falha ao recuperar veiculos");
            }
        }

        public VehicleDto FindById(int id)
        {
            var query = new VehicleQueries().GetVehicleById(id);

            try
            {
                using (_connection)
                {
                    return _connection.QueryFirstOrDefault<VehicleDto>(query.Query, query.Parameters) as VehicleDto;
                }
            }
            catch (Exception)
            {
                throw new Exception("Falha ao recuperar veiculos");
            }
        }

        public IEnumerable<VehicleDto> GetVehicles()
        {
            var query = new VehicleQueries().GetAllVehicle();

            try
            {
                using (_connection)
                {
                    var q = _connection.Query<VehicleDto>(query.Query, query.Parameters) as List<VehicleDto>;

                    return q.ToList();
                }
            }
            catch (Exception)
            {
                throw new Exception("Falha ao recuperar veiculos");
            }
        }
    }
}
