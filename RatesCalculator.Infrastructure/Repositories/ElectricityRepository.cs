
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
   public  class ElectricityRepository: EntityBaseRepository<Electricity>,IElectricityRepository
    {
        public ElectricityRepository(RatesTariffsContext context): base(context)
        {
        }
    }
}
