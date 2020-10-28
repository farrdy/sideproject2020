using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class WaterPropertyBenefitRepository : EntityBaseRepository<WaterPropertyBenefit>, IWaterPropertyBenefitRepository
    {
       public WaterPropertyBenefitRepository(RatesTariffsContext context) : base(context)
        {
        }
    }
}
