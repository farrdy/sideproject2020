using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class RefuseResidentialType
    {
        public int RefuseResidentialTypeId { get; set; }
        public string ResidentialType { get; set; }
        public int RefuseFrequencyWeekly { get; set; }
    }
}
