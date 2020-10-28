
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class RefuseResidentialTypeRepository : EntityBaseRepository<RefuseResidentialType>, IRefuseResidentialTypeRepository
    {

        public RefuseResidentialTypeRepository(RatesTariffsContext context) : base(context)
        {
        }
    }
}

