
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class IndigentIncomeRepository : EntityBaseRepository<IndigentIncomeLevel>,IIndigentIncomeRepository
    {

        public IndigentIncomeRepository(RatesTariffsContext context) : base(context)
        {
        }
    }
}
