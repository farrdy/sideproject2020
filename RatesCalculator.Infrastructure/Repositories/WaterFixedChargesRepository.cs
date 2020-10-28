using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
  
   public  class WaterFixedChargesRepository : EntityBaseRepository<WaterFixedCharges>, IWaterFixedChargesRepository
    {
        public WaterFixedChargesRepository(RatesTariffsContext context) : base(context)
        {

        }
    }
}
