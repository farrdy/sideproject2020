using RatesCalculator.Data;
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class AuditEntityFieldRepository: EntityBaseRepository<AuditEntityField>, IAuditEntityFieldRepository
    {
        public AuditEntityFieldRepository(RatesTariffsContext context): base(context)
        { 
        }
    }

}
