using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
   public class SanitationFreeBenefitRepository: EntityBaseRepository<SanitationFreeBenefit>,ISanitationFreeBenefitRepository
    {
        public SanitationFreeBenefitRepository(RatesTariffsContext context) : base(context)
        { }

    }
}
