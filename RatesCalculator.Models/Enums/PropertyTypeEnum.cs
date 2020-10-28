using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RatesCalculator.Models.Enums
{
   public  enum PropertyTypeEnum
    {
        [Description("FLat=1")]
        Flat =1,
        [Description("Hostel=2")]
        Hostel =2,
        [Description("SectionalTitle=3")]
        SectionalTitle =3,
        [Description("SingleResidence=4")]
        SingleResidence =4

    }
}
