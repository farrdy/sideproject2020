using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class IndigentIncomeLevel
    {
        public int IncomeId { get; set; }
        public decimal IncomeLowerLevel { get; set; }
        public decimal IncomeHigherLevel { get; set; }
        public decimal? Rebate { get; set; }
    }
}
