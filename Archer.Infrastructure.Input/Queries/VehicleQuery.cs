using Archer.Domain.Entities;
using Archer.Infrastructure.Shared.Shared;
using System.Diagnostics;
using System.Drawing;

namespace Archer.Infrastructure.Input.Queries
{
    public class VehicleQuery : BaseQuery
    {
        public QueryModel InsertVehicleQuery(VehicleEntity entity)
        {
            this.Table = Map.GetVehicleTable();
            this.Query = $@"
                INSERT INTO {this.Table}
                VALUES(@Name, @Color, @ModelYear, @CategoryId, @Price, @Type, @CreateOn)";
            
            this.Parameters = new
            {
                Name = entity.Name,
                Color = entity.Color,
                ModelYear = entity.ModelYear,
                CategoryId = entity.CategoryId,
                Price = entity.Price,
                Type = (int)entity.Type,
                CreateOn = entity.CreateOn
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
