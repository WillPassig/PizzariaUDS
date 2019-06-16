using Newtonsoft.Json;
using PizzariaUDS.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzariaUDS.Application.EventSourcedNormalizers
{
    public class OrderHistory
    {
        public static IList<OrderHistoryData> HistoryData { get; set; }

        public static IList<OrderHistoryData> ToJavaScriptOrderHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<OrderHistoryData>();
            OrderHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(o => o.When);
            var list = new List<OrderHistoryData>();
            var last = new OrderHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new OrderHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Price = string.IsNullOrWhiteSpace(change.Price) || change.Price == last.Price
                        ? ""
                        : change.Price,
                    EstimatedPreparationTime = string.IsNullOrWhiteSpace(change.EstimatedPreparationTime) || change.EstimatedPreparationTime == last.EstimatedPreparationTime
                        ? ""
                        : change.EstimatedPreparationTime,
                    PizzaSize = string.IsNullOrWhiteSpace(change.PizzaSize) || change.PizzaSize == last.PizzaSize
                        ? ""
                        : change.PizzaSize,
                    PizzaFlavor = string.IsNullOrWhiteSpace(change.PizzaFlavor) || change.PizzaFlavor == last.PizzaFlavor
                        ? ""
                        : change.PizzaFlavor,
                    PizzaCustomizations = string.IsNullOrWhiteSpace(change.PizzaCustomizations) || change.PizzaCustomizations == last.PizzaCustomizations
                        ? ""
                        : change.PizzaCustomizations,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void OrderHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new OrderHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "OrderRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Price = values["Price"];
                        slot.EstimatedPreparationTime = values["EstimatedPreparationTime"];
                        slot.PizzaSize = values["PizzaSize"];
                        slot.PizzaFlavor = values["PizzaFlavor"];
                        slot.PizzaCustomizations = values["PizzaCustomizations"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "OrderUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Price = values["Price"];
                        slot.EstimatedPreparationTime = values["EstimatedPreparationTime"];
                        slot.PizzaSize = values["PizzaSize"];
                        slot.PizzaFlavor = values["PizzaFlavor"];
                        slot.PizzaCustomizations = values["PizzaCustomizations"];
                        slot.Action = "Registered";
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "OrderRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
