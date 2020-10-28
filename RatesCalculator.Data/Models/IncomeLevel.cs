using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class IncomeLevel
    {
        public int IncomeId { get; set; }
        public decimal IncomeLowerLevel { get; set; }
        public decimal IncomeHigherLevel { get; set; }
    }
}
