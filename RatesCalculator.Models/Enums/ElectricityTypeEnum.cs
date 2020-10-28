using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RatesCalculator.Models.Enums
{
    public enum ElectricityTypeEnum
    {
        [Description("Credit=1")]
        Credit = 1,
        [Description("Prepaid=1")]
        Prepaid = 2

    }
    
}
