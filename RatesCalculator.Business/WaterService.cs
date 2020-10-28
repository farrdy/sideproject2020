using RatesCalculator.Infrastructure.Interfaces;
using RatesCalculator.Models;
using RatesCalculator.Models.Enums;
using RatesCalculator.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RatesCalculator.Service
{
    public class WaterService : IWaterService
    {

        private IWaterRepository _waterRepo = null;
        private IWaterMeterRepository _waterMeterRepo = null;
        private IWaterPropertyBenefitRepository _waterPropBenefit = null;
        private IWaterFixedChargesRepository _fixedCharges = null;

        private IVatRepository _vatRepo = null;

        public WaterService(IWaterRepository waterRepo, IWaterMeterRepository waterMeterRepo, IVatRepository vatRepo, IWaterPropertyBenefitRepository waterPropRepo,IWaterFixedChargesRepository fixedCharges)
        {
            _waterRepo = waterRepo ?? throw new ArgumentNullException(nameof(waterRepo));
            _waterMeterRepo = waterMeterRepo ?? throw new ArgumentNullException(nameof(waterMeterRepo));
            _vatRepo = vatRepo ?? throw new ArgumentNullException(nameof(vatRepo)); ;
            _waterPropBenefit = waterPropRepo ?? throw new ArgumentNullException(nameof(waterPropRepo));
            _fixedCharges = fixedCharges ?? throw new ArgumentNullException(nameof(fixedCharges));

        }
        public WaterOutDto CalculateWater(WaterIn inputObject)
        {
            decimal indigentCharges = 0;
            decimal indigentFreeKl = 0;
            decimal overrallConsumedKl = 0;
            decimal WaterChargeAmountIncVat = 0;
            decimal WaterChargeAmountExcVat = 0;
            decimal waterMeterTariffCharges = 0;
            decimal rangeCharge = 0;
            decimal inclusiveStepWaterExVat = 0;
            decimal previousMaxNonIndigent = 0;
            decimal fixedAmount = 0;
            try
            {
                if (inputObject.PersonType == PersonTypeEnum.Indigent)
                {
                    var indigentWaterMeterExclusion = _waterMeterRepo.GetAll().Where(x => x.PersonTypeId == (int)PersonTypeEnum.Indigent).ToList();
                    var indigentWater = _waterRepo.GetAll().Where(x => x.PersonType == (int)PersonTypeEnum.Indigent).ToList();
                    //Both indigent amd meter number lies in the free range
                    if (indigentWaterMeterExclusion.Count > 0 && indigentWaterMeterExclusion.Any(x => x.MeterSize == inputObject.MeterSize))
                    {
                        waterMeterTariffCharges = 0;
                    }
                    foreach (var indiWater in indigentWater)
                    {
                        if (inputObject.Consumption.IsBetweenWater((decimal)indiWater.MinValue, (decimal)indiWater.MaxValue) && indiWater.Year == DateTime.Now.Year)
                        {
                            WaterChargeAmountExcVat = (decimal)indiWater.ChargeAmount;
                            break;
                        }
                    }


                    foreach (var wpBenefit in _waterPropBenefit.GetAll().ToList())
                    {
                        if (inputObject.PropertyValue.IsBetweenWater((decimal)wpBenefit.PropertyMinValue, (decimal)wpBenefit.PropertyMaxValue))
                        {
                            indigentFreeKl = wpBenefit.FreeConsumptionKl;
                            overrallConsumedKl = inputObject.Consumption - indigentFreeKl;


                            break;
                        }
                    }

                    return new WaterOutDto
                    {
                        ChargeAmountExVat = (overrallConsumedKl * WaterChargeAmountExcVat),
                        ChargeAmountInclVat = (overrallConsumedKl * WaterChargeAmountExcVat) * ((_vatRepo.GetAll().Where(x => x.Year == DateTime.Now.Year).FirstOrDefault().PercentageValue + 100) / 100)


                    };

                }
                else {
                    var WaterMeterChanges = _waterMeterRepo.GetAll().Where(x => x.PersonTypeId != (int)PersonTypeEnum.Indigent).ToList();
                    var WaterStepCharges = _waterRepo.GetAll().Where(x => x.PersonType != (int)PersonTypeEnum.Indigent).ToList();


                    foreach (var t in WaterStepCharges) {

                        if (inputObject.Consumption > t.MaxValue)
                        {
                            inclusiveStepWaterExVat = inclusiveStepWaterExVat + (t.MaxValue * t.ChargeAmount);
                            previousMaxNonIndigent = t.MaxValue;
                            continue;
                        }
                        if (inputObject.Consumption.IsBetweenWater((decimal)t.MinValue, (decimal)t.MaxValue) && t.Year == DateTime.Now.Year) {

                            WaterChargeAmountExcVat = (decimal)t.ChargeAmount;
                            overrallConsumedKl = inputObject.Consumption - previousMaxNonIndigent;

                            break;
                       }


                    }

                    var fixedAmountObj = _fixedCharges.GetAll().Where(x => x.MeterSize == inputObject.MeterSize).FirstOrDefault();

                    if (fixedAmountObj != null && fixedAmountObj.ChargeAmount != 0) {

                        fixedAmount = fixedAmountObj.ChargeAmount;
                    }                  

                    return new WaterOutDto
                    {
                        ChargeAmountExVat = (overrallConsumedKl * WaterChargeAmountExcVat)+ inclusiveStepWaterExVat+fixedAmount,
                        ChargeAmountInclVat = ((overrallConsumedKl * WaterChargeAmountExcVat) + inclusiveStepWaterExVat+fixedAmount)* ((_vatRepo.GetAll().Where(x => x.Year == DateTime.Now.Year).FirstOrDefault().PercentageValue + 100) / 100)


                    };




                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;

        }






    }
}

