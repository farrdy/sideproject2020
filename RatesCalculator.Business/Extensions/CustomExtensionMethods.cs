using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatesCalculator.Service
{
    public static  class CustomExtensionMethods
    {
        public static bool IsBetween(this decimal value, decimal Min, decimal Max)
        {
            // return (value >= Min && value <= Max);
            if (value >= Min && value <= Max) return true;
            else return false;
        }
        public static bool IsBetweenSanitation(this decimal value, decimal Min, decimal Max)
        {
            // return (value >= Min && value <= Max);
            if (value > Min && value <= Max) return true;
            else return false;
        }


        public static bool IsBetweenWater(this decimal value, decimal Min, decimal Max)
        {
            // return (value >= Min && value <= Max);
            if (value > Min && value <= Max) return true;
            else return false;
        }
        
        
    }
}
