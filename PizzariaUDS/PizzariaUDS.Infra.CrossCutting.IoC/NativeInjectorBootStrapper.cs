using PizzariaUDS.Application.Interfaces;
using PizzariaUDS.Application.Services;
using PizzariaUDS.Domain.CommandHandlers;
using PizzariaUDS.Domain.Commands;
using PizzariaUDS.Domain.Core.Bus;
using PizzariaUDS.Domain.Core.Events;
using PizzariaUDS.Domain.Core.Notifications;
using PizzariaUDS.Domain.EventHandlers;
using PizzariaUDS.Domain.Events;
using PizzariaUDS.Domain.Interfaces;
using PizzariaUDS.Infra.CrossCutting.Bus;
using PizzariaUDS.Infra.CrossCutting.Identity.Authorization;
using PizzariaUDS.Infra.CrossCutting.Identity.Models;
using PizzariaUDS.Infra.CrossCutting.Identity.Services;
using PizzariaUDS.Infra.Data.Context;
using PizzariaUDS.Infra.Data.EventSourcing;
using PizzariaUDS.Infra.Data.Repository;
using PizzariaUDS.Infra.Data.Repository.EventSourcing;
using PizzariaUDS.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PizzariaUDS.Domain.Commands.Orders;

namespace PizzariaUDS.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IOrderAppService, OrderAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<OrderRegisteredEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderUpdatedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderRemovedEvent>, OrderEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewOrderCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrderCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveOrderCommand, bool>, OrderCommandHandler>();

            // Infra - Data
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PizzariaUDSContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
