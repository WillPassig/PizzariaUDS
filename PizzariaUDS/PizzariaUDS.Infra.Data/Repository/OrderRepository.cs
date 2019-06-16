using Microsoft.EntityFrameworkCore;
using PizzariaUDS.Domain.Interfaces;
using PizzariaUDS.Domain.Models;
using PizzariaUDS.Infra.Data.Context;

namespace PizzariaUDS.Infra.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(PizzariaUDSContext context) : base(context)
        {

        }
    }
}
