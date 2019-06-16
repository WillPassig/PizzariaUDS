using PizzariaUDS.Domain.Commands.Orders;

namespace PizzariaUDS.Domain.Validations.Orders
{
    public class RegisterNewOrderCommandValidation : OrderValidation<RegisterNewOrderCommand>
    {
        public RegisterNewOrderCommandValidation()
        {
            ValidatePizzaOrdered();
        }
    }
}
