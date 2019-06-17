using PizzariaUDS.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzariaUDS.Domain.Models
{
    public class Order : Entity
    {
        public Pizza Pizza { get; set; }

        public Order(Guid id, Pizza pizza)
        {
            Id = id;
            Pizza = pizza;
        }

        // Empty constructor for EF
        protected Order() { }
    }
}
