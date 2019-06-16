using PizzariaUDS.Domain.Core.Commands;
using PizzariaUDS.Domain.Models;
using System;

namespace PizzariaUDS.Domain.Commands.Orders
{
    public abstract class OrderCommand : Command
    {
        public Guid Id { get; set; }

        public Pizza Pizza { get; set; }
    }
}
