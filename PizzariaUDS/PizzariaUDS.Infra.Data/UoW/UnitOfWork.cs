using PizzariaUDS.Domain.Interfaces;
using PizzariaUDS.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzariaUDS.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PizzariaUDSContext _context;

        public UnitOfWork(PizzariaUDSContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
