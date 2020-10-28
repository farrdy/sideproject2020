using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class PersonType
    {
        public int PersonTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual PropertyRebates PropertyRebates { get; set; }
    }
}
