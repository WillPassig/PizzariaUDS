using PizzariaUDS.Domain.Validations.Orders;
using System;

namespace PizzariaUDS.Domain.Commands.Orders
{
    public class RemoveOrderCommand : OrderCommand
    {
        public RemoveOrderCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
