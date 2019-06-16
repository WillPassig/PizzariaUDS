using PizzariaUDS.Domain.Core.Events;
using PizzariaUDS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzariaUDS.Domain.Events
{
    public class OrderRegisteredEvent : Event
    {
        public Guid Id { get; set; }

        public Pizza Pizza { get; set; }

        public OrderRegisteredEvent(Guid id, Pizza pizza)
        {
            Pizza = pizza;
            Id = id;
        }
    }
}
