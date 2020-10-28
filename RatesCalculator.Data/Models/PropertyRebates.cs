using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class PropertyRebates
    {
        public int PropertyRebatesId { get; set; }
        public int IncomeLevel { get; set; }
        public decimal MinIncome { get; set; }
        public decimal MaxIncome { get; set; }
        public int Year { get; set; }
        public decimal RebatePercent { get; set; }
        public int PersonTypeId { get; set; }

        public virtual PersonType PropertyRebatesNavigation { get; set; }
    }
}
