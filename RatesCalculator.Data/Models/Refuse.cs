using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class Refuse
    {
        public int RefuseId { get; set; }
        public string Unit { get; set; }
        public int Year { get; set; }
        public decimal ChargeAmountIncVat { get; set; }
        public decimal ChargeAmountExVat { get; set; }
    }
}
