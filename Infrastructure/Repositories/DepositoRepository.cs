using System;
using System.Collections.Generic;
using System.Text;
using Domain.Contracts;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class DepositoRepository : GenericRepository<Deposito>, IServicioInversionRepository
    {
        public DepositoRepository(IDbContext context)
              : base(context)
        {

        }
    }
}
