
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class PropertyValueRefuseRebatesRepository : EntityBaseRepository<PropertyValueRefuseRebates>, IPropertyValueRefuseRebatesRepository
    {
        public PropertyValueRefuseRebatesRepository(RatesTariffsContext context): base(context)
        { }
    }
}
