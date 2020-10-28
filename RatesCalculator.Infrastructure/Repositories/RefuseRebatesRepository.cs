
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
  public  class RefuseRebatesRepository : EntityBaseRepository<RefuseRebates>, IRefuseRebatesRepository
    {
        public RefuseRebatesRepository(RatesTariffsContext context)      : base(context)
        { }
    }
}
