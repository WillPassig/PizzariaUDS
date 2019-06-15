using System;
using System.Collections.Generic;
using System.Text;

namespace PizzariaUDS.Domain.Core.Models
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}
