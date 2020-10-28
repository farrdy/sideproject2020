
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class AuditEntityRepository:EntityBaseRepository<AuditEntity>, IAuditEntityRepository
    {
        public AuditEntityRepository(RatesTariffsContext context): base(context)
        {
        }
    }

}
