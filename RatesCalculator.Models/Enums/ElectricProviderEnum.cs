using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RatesCalculator.Models.Enums
{
    public enum  ElectricProviderEnum
    {
        [Description("Cape Town=1")]
        Capetown =1,

        [Description("Eskom =1")]
        Eskom =2
    }
}
