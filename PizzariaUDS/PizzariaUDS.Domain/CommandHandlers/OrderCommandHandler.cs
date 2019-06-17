using MediatR;
using PizzariaUDS.Domain.Commands.Orders;
using PizzariaUDS.Domain.Core.Bus;
using PizzariaUDS.Domain.Core.Notifications;
using PizzariaUDS.Domain.Events;
using PizzariaUDS.Domain.Interfaces;
using PizzariaUDS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzariaUDS.Domain.CommandHandlers
{
    public class OrderCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewOrderCommand, bool>,
        IRequestHandler<UpdateOrderCommand, bool>,
        IRequestHandler<RemoveOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediatorHandler Bus;

        public OrderCommandHandler(IOrderRepository orderRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _orderRepository = orderRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var order = new Order(Guid.NewGuid(), message.Pizza);

            _orderRepository.Add(order);

            if (Commit())
            {
                Bus.RaiseEvent(new OrderRegisteredEvent(order.Id, order.Pizza));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var order = new Order(message.Id, message.Pizza);
            var existingOrder = _orderRepository.GetById(order.Id);

            if (existingOrder != null && existingOrder.Id != order.Id)
            {
                if (!existingOrder.Equals(order))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "Already exists."));
                    return Task.FromResult(false);
                }
            }

            _orderRepository.Update(order);

            if (Commit())
            {
                Bus.RaiseEvent(new OrderUpdatedEvent(order.Id, order.Pizza));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _orderRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new OrderRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _orderRepository.Dispose();
        }
    }
}
