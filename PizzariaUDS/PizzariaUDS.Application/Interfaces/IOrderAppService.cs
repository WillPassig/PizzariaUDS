using PizzariaUDS.Application.EventSourcedNormalizers;
using PizzariaUDS.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzariaUDS.Application.Interfaces
{
    public interface IOrderAppService : IDisposable
    {
        void Register(OrderViewModel OrderViewModel);
        IEnumerable<OrderViewModel> GetAll();
        OrderViewModel GetById(Guid id);
        void Update(OrderViewModel OrderViewModel);
        void Remove(Guid id);
        IList<OrderHistoryData> GetAllHistory(Guid id);
    }
}
