using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Models
{
   public class SanitationOutDto
    {

        /// <summary>
        /// ChargeAmountExVat charges.
        /// </summary>      
      
        public decimal ChargeAmountExVat { get; set; }

        /// <summary>
        /// ChargeAmountInclVat charges.
        /// </summary>
      
        public decimal ChargeAmountInclVat { get; set; }
    }
}
