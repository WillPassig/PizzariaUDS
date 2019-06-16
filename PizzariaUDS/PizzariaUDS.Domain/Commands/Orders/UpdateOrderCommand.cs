using PizzariaUDS.Domain.Models;
using PizzariaUDS.Domain.Validations.Orders;
using System;

namespace PizzariaUDS.Domain.Commands.Orders
{
    public class UpdateOrderCommand : OrderCommand
    {
        public UpdateOrderCommand(Guid id, Pizza pizza)
        {
            Id = id;
            Pizza = pizza;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
