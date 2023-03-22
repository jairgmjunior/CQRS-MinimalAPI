using Archer.Application.Input.Commands.Interfaces;

namespace Archer.Application.Input.Receivers.Interfaces
{
    public interface IReceiver<in T, out W> where T : ICommand where W : State
    {
       W Action(T command);
    }
}
