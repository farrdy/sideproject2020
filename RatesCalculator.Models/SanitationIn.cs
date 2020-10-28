using RatesCalculator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Models
{
    public class SanitationIn
    {

        /// <summary>
        /// Indigent, Pensioner , Disabled .
        /// </summary>      

        public PersonTypeEnum PersonType { get; set; }

        /// <summary>
        /// Consumption in kl .
        /// </summary>      

        public decimal Consumption { get; set; }


        /// <summary>
        /// Value of Property
        /// </summary>      

        public decimal PropertyValue { get; set; }

    }
}
