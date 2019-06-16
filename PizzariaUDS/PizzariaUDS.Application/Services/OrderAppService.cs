using AutoMapper;
using AutoMapper.QueryableExtensions;
using PizzariaUDS.Application.EventSourcedNormalizers;
using PizzariaUDS.Application.Interfaces;
using PizzariaUDS.Application.ViewModels;
using PizzariaUDS.Domain.Commands.Orders;
using PizzariaUDS.Domain.Core.Bus;
using PizzariaUDS.Domain.Interfaces;
using PizzariaUDS.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;

namespace PizzariaUDS.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _OrderRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public OrderAppService(IMapper mapper,
                                  IOrderRepository OrderRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _OrderRepository = OrderRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            return _OrderRepository.GetAll().ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);
        }

        public OrderViewModel GetById(Guid id)
        {
            return _mapper.Map<OrderViewModel>(_OrderRepository.GetById(id));
        }

        public void Register(OrderViewModel OrderViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewOrderCommand>(OrderViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(OrderViewModel OrderViewModel)
        {
            var updateCommand = _mapper.Map<UpdateOrderCommand>(OrderViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveOrderCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<OrderHistoryData> GetAllHistory(Guid id)
        {
            return OrderHistory.ToJavaScriptOrderHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
