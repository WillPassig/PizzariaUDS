using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzariaUDS.Application.Interfaces;
using PizzariaUDS.Application.ViewModels;
using PizzariaUDS.Domain.Core.Bus;
using PizzariaUDS.Domain.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaUDS.Services.API.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        private readonly IOrderAppService _OrderAppService;

        public OrderController(
            IOrderAppService OrderAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _OrderAppService = OrderAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("order")]
        public IActionResult Get()
        {
            return Response(_OrderAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("order/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var OrderViewModel = _OrderAppService.GetById(id);

            return Response(OrderViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("order")]
        public IActionResult Post([FromBody]OrderViewModel OrderViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(OrderViewModel);
            }

            _OrderAppService.Register(OrderViewModel);

            return Response(OrderViewModel);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("order")]
        public IActionResult Put([FromBody]OrderViewModel OrderViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(OrderViewModel);
            }

            _OrderAppService.Update(OrderViewModel);

            return Response(OrderViewModel);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("order")]
        public IActionResult Delete(Guid id)
        {
            _OrderAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("order/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var OrderHistoryData = _OrderAppService.GetAllHistory(id);
            return Response(OrderHistoryData);
        }
    }
}
