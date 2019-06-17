using PizzariaUDS.Domain.Models.Pizzas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Application.ViewModels
{
    public class OrderViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [EnumDataType(typeof(PizzaSize))]
        [DisplayName("PizzaSize")]
        public PizzaSize PizzaSize { get; set; }

        [Required]
        [EnumDataType(typeof(PizzaFlavor))]
        [DisplayName("PizzaFlavor")]
        public PizzaFlavor PizzaFlavor { get; set; }

        [Required]
        [DisplayName("PizzaCustomizations")]
        public List<PizzaCustomization> PizzaCustomizations { get; set; }

    }
}
