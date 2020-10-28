using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class WaterMeter
    {
        public int WaterMeterId { get; set; }
        public decimal MeterSize { get; set; }
        public int Year { get; set; }
        public decimal ValueExclVat { get; set; }
        public decimal ValueWithVat { get; set; }
        public int PersonTypeId { get; set; }
    }
}
