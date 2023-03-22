using Archer.Application.Input.Commands.Interfaces;
using Archer.Domain.Enums;

namespace Archer.Application.Input.Commands.VehicleContext
{
    public class VehicleCommand : ICommand
    {
        public string? Name { get;  set; }
        public string? Color { get; set; }
        public int ModelYear { get;  set; }
        public double Price { get;  set; }
        public int CategoryId { get; set; }
        public EVehicleType Type { get; set; }
    }
}
