using PizzariaUDS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzariaUDS.Domain.Events
{
    public class OrderRemovedEvent : Event
    {
        public Guid Id { get; set; }

        public OrderRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
