using PizzariaUDS.Domain.Models.Pizzas;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzariaUDS.Application.ViewModels
{
    public class OrderViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Price")]
        [Range(0, double.MaxValue)]
        public string Price { get; set; }

        [Required]
        [DisplayName("EstimatedPreparationTime")]
        [Range(0, int.MaxValue)]
        public string EstimatedPreparationTime { get; set; }

        [Required]
        [EnumDataType(typeof(PizzaSize))]
        [DisplayName("PizzaSize")]
        public string PizzaSize { get; set; }

        [Required]
        [EnumDataType(typeof(PizzaFlavor))]
        [DisplayName("PizzaFlavor")]
        public string PizzaFlavor { get; set; }

        [Required]
        [DisplayName("PizzaCustomizations")]
        public string PizzaCustomizations { get; set; }

    }
}
