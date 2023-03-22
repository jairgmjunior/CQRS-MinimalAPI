using Archer.Application.Input.Commands.VehicleContext;
using Archer.Application.Input.Receivers.Interfaces;
using Archer.Application.Input.Repositories;
using Archer.Domain.Entities;

namespace Archer.Application.Input.Receivers
{
    public class InsertVehicleReceiver : IReceiver<VehicleCommand, State>
    {
        private readonly IWriteVehicleRepository _repository;

        public InsertVehicleReceiver(IWriteVehicleRepository repository)
        {
            _repository = repository;
        }

        public State Action(VehicleCommand command)
        {
            var vehicle = new VehicleEntity(
                command.Name, 
                command.Color, 
                command.ModelYear, 
                command.CategoryId, 
                command.Price, 
                command.Type);

            if (!vehicle.IsValid()) 
                return new State(400, "Falha so inserir, verifique os campos", vehicle.Notifications);
            try
            {
                _repository.InsertVehicle(vehicle);
                return new State(200, "Sucesso", vehicle);
            }
            catch(Exception ex)
            {
                return new State(500, ex.Message, null);
            }
        }
    }
}
