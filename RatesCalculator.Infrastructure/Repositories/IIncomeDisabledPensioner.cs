using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class IncomeDisabledPensionerRepository : EntityBaseRepository<PensionerDisabledIncome>, IIncomeDisbaledPensionerRepository
    {
        public IncomeDisabledPensionerRepository(RatesTariffsContext context) : base(context)
        {
        }
    }
}
