using AutoMapper;
using PizzariaUDS.Application.ViewModels;
using PizzariaUDS.Domain.Models;

namespace PizzariaUDS.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}
