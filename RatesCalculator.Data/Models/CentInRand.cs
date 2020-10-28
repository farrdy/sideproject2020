using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class CentInRand
    {
        public int CentInRandId { get; set; }
        public int Year { get; set; }
        public decimal Value { get; set; }
    }
}
