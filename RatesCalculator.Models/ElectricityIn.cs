using RatesCalculator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Models
{
    public class ElectricityIn
    {


        
        public ElectricityTypeEnum electricityMeterType { get; set; }
        public ElectricityCategoryEnum electricityCategory { get; set; }

        public PersonTypeEnum personType { get; set; }

        public decimal PropertyValue { get; set; }

        public decimal Consumption { get; set; }

        public ElectricProviderEnum ElectricProviderName { get; set; }



    }
}
