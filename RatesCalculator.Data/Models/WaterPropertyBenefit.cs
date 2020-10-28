using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class WaterPropertyBenefit
    {
        public int WaterPropertyId { get; set; }
        public decimal PropertyMinValue { get; set; }
        public decimal PropertyMaxValue { get; set; }
        public decimal FreeConsumptionKl { get; set; }
    }
}
