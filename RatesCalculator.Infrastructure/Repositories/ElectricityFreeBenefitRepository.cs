using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class ElectricityFreeBenefitRepository: EntityBaseRepository<ElectricityFreeBenefit>, IElectricityFreeBenefitRepository
    {
        public ElectricityFreeBenefitRepository(RatesTariffsContext context) : base(context)
        {
        }

    }
}
