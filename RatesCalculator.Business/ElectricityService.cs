using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using RatesCalculator.Models;
using RatesCalculator.Models.Enums;
using RatesCalculator.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatesCalculator.Service
{
    public class ElectricityService : IElectricityService
    {
        private IPersonTypeRepository _personTypeRebates = null;
        private IElectricityRepository _electritRepo = null;
        private IVatRepository _vatRepo = null;
        private IElectricityFreeBenefitRepository _electricityFreeBenefit = null;
        public ElectricityService(IElectricityRepository electritRepo, IElectricityFreeBenefitRepository electricFreebenefit, IPersonTypeRepository personType, IVatRepository vatrepo)
        {
            _electricityFreeBenefit = electricFreebenefit ?? throw new ArgumentNullException(nameof(electricFreebenefit));
            _electritRepo = electritRepo ?? throw new ArgumentNullException(nameof(electritRepo));
            _personTypeRebates = personType ?? throw new ArgumentNullException(nameof(personType));
            _vatRepo = vatrepo ?? throw new ArgumentNullException(nameof(vatrepo)); ;
        }

        public ElectricOut CalculateElectricity(ElectricityIn inputObj)
        {

            decimal continuousCharge = 0;
            decimal freeKwh = 0;
            decimal electricityChargeAmt = 0;


            //foreach (var item in _electritRepo.GetAll())
            //{



            //    if (inputObj.Consumption.IsBetween((decimal)item.ConsumptionMinLevel, (decimal)item.ConstumptionMaxLevel) && inputObj.PropertyValue.IsBetween((decimal)item.MinPropertyValue, (decimal)item.MaxPropertyValue))
            //    {


            //        if (inputObj.Consumption > item.ConstumptionMaxLevel)
            //        {
            //            continuousCharge = continuousCharge + (inputObj.Consumption * item.TariffAmount);

            //        }
            //        var chargeExvat = item.TariffAmount;

            //        break;
            //    }
            //}


            //Calculates Indigent consumption
            if (inputObj.personType == PersonTypeEnum.Indigent || inputObj.personType == PersonTypeEnum.Pensioner || inputObj.personType == PersonTypeEnum.Disabled)
            {

                inputObj.electricityCategory = ElectricityCategoryEnum.Lifeline;

                var lifelineTarifs = _electritRepo.GetAll().Where(x => x.TypeOfElectricity.Equals(ElectricityCategoryEnum.Lifeline));
                foreach (var item in lifelineTarifs)
                {

                    if (inputObj.Consumption.IsBetween((decimal)item.ConsumptionMinLevel, (decimal)item.ConstumptionMaxLevel) && inputObj.PropertyValue.IsBetween((decimal)item.MinPropertyValue, (decimal)item.MaxPropertyValue) && item.Year == DateTime.Now.Year)
                    {
                        if (inputObj.Consumption > item.ConstumptionMaxLevel)
                        {
                            continuousCharge = continuousCharge + item.TariffAmount;
                            continue;
                        }


                        var chargeExvat = item.TariffAmount;

                        break;
                    }


                }

            }
            //Calculates the free Kwh 
            foreach (var indexItem in _electricityFreeBenefit.GetAll())
            {

                if ((indexItem.ProviderName.Equals(ElectricProviderEnum.Capetown)) && (inputObj.Consumption.IsBetween((decimal)indexItem.MinConsumption, (decimal)indexItem.MaxConsumption)))
                {

                    freeKwh = (decimal)indexItem.FreeUnits;
                }

            }


            //Calculates Home User Charges

            if (!(inputObj.personType == PersonTypeEnum.Indigent || inputObj.personType == PersonTypeEnum.Pensioner || inputObj.personType == PersonTypeEnum.Disabled))
            {

                var homeUserCharges = _electritRepo.GetAll().Where(x => x.TypeOfElectricity.Equals(ElectricityCategoryEnum.Homeuser)).ToList();

                foreach (var indexItem in homeUserCharges)
                {
                    //property value is gretter than 1 Million
                    if ( (inputObj.electricityMeterType == ElectricityTypeEnum.Credit) || ((inputObj.electricityMeterType == ElectricityTypeEnum.Prepaid)&&(indexItem.MinPropertyValue < inputObj.PropertyValue)))
                    {
                        if (inputObj.Consumption > indexItem.ConstumptionMaxLevel)
                        {
                            continuousCharge = continuousCharge + indexItem.TariffAmount;                           
                        }
                        electricityChargeAmt = indexItem.TariffAmount;
                        continue;
                    }
                    break;

                }

            }



            //Domestic user Charges
            var domesticTarifs = _electritRepo.GetAll().Where(x => x.TypeOfElectricity.Equals(ElectricityCategoryEnum.Domestic));

            foreach (var item in domesticTarifs.ToList())
            {

                if (inputObj.PropertyValue > item.MaxPropertyValue)
                {

                    var consumption = inputObj.Consumption - item.ConstumptionMaxLevel;
                    continuousCharge = continuousCharge + item.TariffAmount;
                }

                if (inputObj.PropertyValue.IsBetween((decimal)item.MinPropertyValue, (decimal)item.MaxPropertyValue))
                {
                    //Apply domestic tarifs


                }

            }



            return null;
        }


    }
}
