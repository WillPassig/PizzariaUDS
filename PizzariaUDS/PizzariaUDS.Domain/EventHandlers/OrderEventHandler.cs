using MediatR;
using PizzariaUDS.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzariaUDS.Domain.EventHandlers
{
    public class OrderEventHandler :
        INotificationHandler<OrderRegisteredEvent>,
        INotificationHandler<OrderUpdatedEvent>,
        INotificationHandler<OrderRemovedEvent>
    {
        public Task Handle(OrderUpdatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderRegisteredEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderRemovedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
