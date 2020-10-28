
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class WaterRepository:EntityBaseRepository<Water>, IWaterRepository
    {
        public WaterRepository(RatesTariffsContext context) : base(context)
        {
        }

    }
}
