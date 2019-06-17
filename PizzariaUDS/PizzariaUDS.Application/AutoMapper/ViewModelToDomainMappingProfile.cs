using AutoMapper;
using PizzariaUDS.Application.ViewModels;
using PizzariaUDS.Domain.Commands.Orders;
using PizzariaUDS.Domain.Models;

namespace PizzariaUDS.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<OrderViewModel, RegisterNewOrderCommand>()
                .ConstructUsing(o => new RegisterNewOrderCommand(new Pizza(o.PizzaSize, o.PizzaFlavor, o.PizzaCustomizations)));

            CreateMap<OrderViewModel, UpdateOrderCommand>()
                .ConstructUsing(o => new UpdateOrderCommand(o.Id, new Pizza(o.PizzaSize, o.PizzaFlavor, o.PizzaCustomizations)));
        }
    }
}
