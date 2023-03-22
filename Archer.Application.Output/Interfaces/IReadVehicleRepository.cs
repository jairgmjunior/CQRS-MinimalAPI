using Archer.Application.Output.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Application.Output.Interfaces
{
    public interface IReadVehicleRepository
    {
        IEnumerable<VehicleDto> GetVehicles();
        VehicleDto FindById(int id);
        IEnumerable<VehicleDto> FindByCategoryId(int categoryId);
    }
}
