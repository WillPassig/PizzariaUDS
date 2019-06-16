using PizzariaUDS.Domain.Commands.Orders;

namespace PizzariaUDS.Domain.Validations.Orders
{
    public class RemoveOrderCommandValidation : OrderValidation<RemoveOrderCommand>
    {
        public RemoveOrderCommandValidation()
        {
            ValidateId();
        }
    }
}
