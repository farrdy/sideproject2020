using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class RefuseRebates
    {
        public int RefuseRebatesId { get; set; }
        public decimal PropertyMinValue { get; set; }
        public decimal PropertyMaxValue { get; set; }
        public int Year { get; set; }
        public decimal RebatePercent { get; set; }
    }
}
