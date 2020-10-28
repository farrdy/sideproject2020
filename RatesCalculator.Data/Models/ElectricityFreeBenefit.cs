using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class ElectricityFreeBenefit
    {
        public int? ProviderId { get; set; }
        public string ProviderName { get; set; }
        public decimal? MinConsumption { get; set; }
        public decimal? MaxConsumption { get; set; }
        public decimal? FreeUnits { get; set; }
    }
}
