using PizzariaUDS.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzariaUDS.Domain.Models
{
    public class Order : Entity
    {
        public Pizza Pizza { get; set; }

        protected Order() { }
    }
}
