using RatesCalculator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Models
{
    public class RefuseIn
    {

        /// <summary>
        /// Property Value .
        /// </summary>    

        public decimal PropertyValue { get; set; }
        /// <summary>
        /// Type of dwelling .
        /// </summary>    
        public PropertyTypeEnum PropertyType { get; set; }


        /// <summary>
        /// Number of bins.
        /// </summary>    
        public int NumberOfBins { get; set; }

        public decimal BinSize { get; set; }

        /// <summary>
        /// Resident Type.
        /// </summary>    
        public PersonTypeEnum  PersonType { get; set; }


        /// <summary>
        /// Income.
        /// </summary>    
        public decimal Income { get; set; }




    }
}
