using PizzariaUDS.Domain.Core.Models;
using PizzariaUDS.Domain.Models.Pizzas;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzariaUDS.Domain.Models
{
    public class Pizza : Entity
    {
        public PizzaSize PizzaSize { get; set; }

        public List<PizzaCustomization> Customizations { get; set; }

        public double Price { get; set; }

        public Pizza()
        {

        }
    }
}
