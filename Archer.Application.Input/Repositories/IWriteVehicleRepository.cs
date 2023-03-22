using Archer.Domain.Entities;

namespace Archer.Application.Input.Repositories
{
    public interface IWriteVehicleRepository
    {
        void InsertVehicle(VehicleEntity vehicle);
    }
}
