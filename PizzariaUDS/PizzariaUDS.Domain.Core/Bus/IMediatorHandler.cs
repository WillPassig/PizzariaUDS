using PizzariaUDS.Domain.Core.Commands;
using PizzariaUDS.Domain.Core.Events;
using System.Threading.Tasks;

namespace PizzariaUDS.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
