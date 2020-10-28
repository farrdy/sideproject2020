using RatesCalculator.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RatesCalculator.Models
{
   public  class WaterIn
    {
        /// <summary>
        /// Indigent, Pensioner , Disabled .
        /// </summary>      

        public PersonTypeEnum PersonType { get; set; }

        /// <summary>
        /// Meter size in mm.
        /// </summary>  
        public int MeterSize { get; set; }

        /// <summary>
        /// Consumption in Kl.
        /// </summary>  
        public decimal Consumption { get; set; }


        /// <summary>
        /// Property value.
        /// </summary> 
        public decimal PropertyValue { get; set; }
    }
}
