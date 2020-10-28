using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class ResidentWasteCollection
    {
        public int ResidentWasteCollectionId { get; set; }
        public string Unit { get; set; }
        public int Year { get; set; }
        public decimal ChargeAmount { get; set; }
    }
}
