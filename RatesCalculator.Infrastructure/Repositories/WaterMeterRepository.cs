
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class WaterMeterRepository:EntityBaseRepository<WaterMeter>, IWaterMeterRepository
    {
        public WaterMeterRepository(RatesTariffsContext context) : base(context)
        {
        }
    }
}
