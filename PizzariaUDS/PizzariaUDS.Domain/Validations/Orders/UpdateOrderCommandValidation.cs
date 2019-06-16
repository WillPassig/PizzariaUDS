using PizzariaUDS.Domain.Commands.Orders;

namespace PizzariaUDS.Domain.Validations.Orders
{
    public class UpdateOrderCommandValidation : OrderValidation<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidation()
        {
            ValidateId();
            ValidatePizzaOrdered();
        }
    }
}
