using System;
using System.Collections.Generic;
using System.Text;

namespace PizzariaUDS.Application.EventSourcedNormalizers
{
    public class OrderHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Price { get; set; }
        public string EstimatedPreparationTime { get; set; }
        public string PizzaSize { get; set; }
        public string PizzaFlavor { get; set; }
        public string PizzaCustomizations { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
