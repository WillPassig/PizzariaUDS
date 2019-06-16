using FluentValidation;
using PizzariaUDS.Domain.Commands.Orders;
using System;

namespace PizzariaUDS.Domain.Validations.Orders
{
    public abstract class OrderValidation<T> : AbstractValidator<T> where T : OrderCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidatePizzaOrdered()
        {
            RuleFor(o => o.Pizza).NotEmpty();
            //RuleFor(o => o.Pizza.Validate());
        }
    }
}
