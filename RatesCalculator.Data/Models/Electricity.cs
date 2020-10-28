using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class Electricity
    {
        public int ElectricityId { get; set; }
        public string TypeOfElectricity { get; set; }
        public int Block { get; set; }
        public string Unit { get; set; }
        public decimal ConsumptionMinLevel { get; set; }
        public decimal ConstumptionMaxLevel { get; set; }
        public int Year { get; set; }
        public decimal TariffAmount { get; set; }
        public decimal? PropposedTariff { get; set; }
        public decimal? MinPropertyValue { get; set; }
        public decimal? MaxPropertyValue { get; set; }
    }
}
