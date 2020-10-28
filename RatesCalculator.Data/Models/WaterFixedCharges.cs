using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class WaterFixedCharges
    {
        public int FixedChargeId { get; set; }
        public int MeterSize { get; set; }
        public decimal ChargeAmount { get; set; }
        public int? PersonTypeId { get; set; }
    }
}
