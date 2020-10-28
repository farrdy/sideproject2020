using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class RefuseRebatesIndigent
    {
        public int RefuseRebatesIndigentId { get; set; }
        public int IncomeLevel { get; set; }
        public decimal MinIncome { get; set; }
        public decimal MaxIncome { get; set; }
        public decimal RebatePercentage { get; set; }
    }
}
