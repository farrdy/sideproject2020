using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class CentInRandRepository:EntityBaseRepository<CentInRand>,ICentInRandRepository
    {
        public CentInRandRepository(RatesTariffsContext context): base(context)
        { }
    }
}
