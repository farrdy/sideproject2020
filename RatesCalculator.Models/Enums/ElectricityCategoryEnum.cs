using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RatesCalculator.Models.Enums
{
    public enum ElectricityCategoryEnum
    {
        [Description("Life Line=1")]
        Lifeline =1,
        [Description("Home User=2")]
        Homeuser =2,
        [Description("Domestic=3")]
        Domestic =3
    }
}
