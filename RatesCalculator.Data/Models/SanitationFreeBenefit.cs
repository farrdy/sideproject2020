using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class SanitationFreeBenefit
    {
        public int Id { get; set; }
        public int PersonTypeId { get; set; }
        public decimal PropertyMinValue { get; set; }
        public decimal PropertyMaxValue { get; set; }
        public decimal FreeConsumption { get; set; }
    }
}
