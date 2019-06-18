using FluentValidation;
using FluentValidation.Results;
using PizzariaUDS.Domain.Core.Models;
using PizzariaUDS.Domain.Models.Pizzas;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PizzariaUDS.Domain.Models
{
    public class Pizza : Entity
    {
        public PizzaSize Size { get; set; }
        
        public PizzaFlavor Flavor { get; set; }

        [NotMapped]
        public List<PizzaCustomization> Customizations { get; set; }

        public double Price { get; set; }

        public int EstimatedPreparationTime { get; set; }

        protected Pizza() { }

        public Pizza(PizzaSize size, PizzaFlavor flavor, List<PizzaCustomization> customizations = null)
        {
            Size = size;
            Flavor = flavor;
            Customizations = customizations ?? new List<PizzaCustomization>();

            CalculatePriceAndEstimatedTime();
        }

        private void CalculatePriceAndEstimatedTime()
        {
            Price = 0;
            EstimatedPreparationTime = 0;

            Validate();

            ProcessSize(Size);
            ProcessFlavor(Flavor);
            ProcessCustomizations(Customizations);
        }

        private void ProcessSize(PizzaSize size)
        {
            switch (size)
            {
                case PizzaSize.SMALL:
                    Price += 20;
                    EstimatedPreparationTime += 15;
                    break;
                case PizzaSize.MEDIUM:
                    Price += 30;
                    EstimatedPreparationTime += 20;
                    break;
                case PizzaSize.LARGE:
                    Price += 40;
                    EstimatedPreparationTime += 25;
                    break;
            }
        }

        private void ProcessFlavor(PizzaFlavor flavor)
        {
            switch (flavor)
            {
                case PizzaFlavor.CALABRESA:
                    break;
                case PizzaFlavor.MARGUERITA:
                    break;
                case PizzaFlavor.PORTUGUESA:
                    EstimatedPreparationTime += 5;
                    break;
            }
        }

        private void ProcessCustomizations(List<PizzaCustomization> customizations)
        {
            foreach (var customization in customizations)
            {
                switch (customization)
                {
                    case PizzaCustomization.EXTRA_BACON:
                        Price += 3;
                        break;
                    case PizzaCustomization.NO_ONIONS:
                        break;
                    case PizzaCustomization.STUFFED_CRUST:
                        Price += 5;
                        EstimatedPreparationTime += 5;
                        break;
                    default:
                        break;
                }
            }
        }

        public virtual ValidationResult Validate()
        {
            PizzaValidation pizzaValidation = new PizzaValidation();

            return pizzaValidation.Validate(this);
        }

        private class PizzaValidation : AbstractValidator<Pizza>
        {
            public PizzaValidation()
            {
                RuleFor(pizza => pizza.Size).NotEmpty();

                RuleFor(pizza => pizza.Flavor).NotEmpty();

                RuleFor(pizza => pizza.Customizations.Count).GreaterThanOrEqualTo(0);
                RuleFor(pizza => pizza.Customizations.Count).LessThanOrEqualTo(3);

                RuleFor(pizza => pizza.Price).GreaterThanOrEqualTo(0);

                RuleFor(pizza => pizza.EstimatedPreparationTime).GreaterThanOrEqualTo(0);
            }
        }
    }
}
