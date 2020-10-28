
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class SanitationRepository:EntityBaseRepository<Sanitation>, ISanitationRepository
    {
        public SanitationRepository(RatesTariffsContext context) : base(context)
        {
        }
    }
}
