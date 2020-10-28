using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class Water
    {
        public int WaterId { get; set; }
        public string WaterType { get; set; }
        public int WaterStep { get; set; }
        public string WaterUnit { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public int Year { get; set; }
        public decimal ChargeAmount { get; set; }
        public decimal ProposedTariff { get; set; }
        public int PersonType { get; set; }
    }
}
