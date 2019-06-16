using PizzariaUDS.Domain.Models;
using PizzariaUDS.Domain.Validations.Orders;

namespace PizzariaUDS.Domain.Commands.Orders
{
    public class RegisterNewOrderCommand : OrderCommand
    {
        public RegisterNewOrderCommand(Pizza pizza)
        {
            Pizza = pizza;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
