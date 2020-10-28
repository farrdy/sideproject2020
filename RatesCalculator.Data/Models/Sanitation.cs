using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class Sanitation
    {
        public int SanitationId { get; set; }
        public int? PersonTypeId { get; set; }
        public int SanitationStep { get; set; }
        public string SanitationUnit { get; set; }
        public decimal MinConstumptValue { get; set; }
        public decimal MaxConstumptValue { get; set; }
        public int Year { get; set; }
        public decimal ChargeAmountExVat { get; set; }
    }
}
