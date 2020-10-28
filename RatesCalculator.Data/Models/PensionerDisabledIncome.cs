using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class PensionerDisabledIncome
    {
        public int IncomeLevelId { get; set; }
        public decimal? LowerIncomeLevel { get; set; }
        public decimal? HigherIncomeLevel { get; set; }
        public decimal? Rebate { get; set; }
    }
}
