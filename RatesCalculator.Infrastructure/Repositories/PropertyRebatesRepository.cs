﻿
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class PropertyRebatesRepository:EntityBaseRepository<PropertyRebates>, IPropertyRebatesRepository
    {
        public PropertyRebatesRepository(RatesTariffsContext context) : base(context)
        {
        }
    }
}
