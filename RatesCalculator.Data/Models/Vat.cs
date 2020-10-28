using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class Vat
    {
        public int VatId { get; set; }
        public int Year { get; set; }
        public decimal PercentageValue { get; set; }
    }
}
