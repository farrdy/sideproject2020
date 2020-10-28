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
    public class SanitationService : ISanitationService
    {
        private IPersonTypeRepository _personTypeRepo = null;
        private ISanitationRepository _sanitationRepo = null;
        private ISanitationFreeBenefitRepository _saniFreeRepo = null;

        private IVatRepository _vatRepo = null;

        public SanitationService(IPersonTypeRepository personRepo, ISanitationRepository sanitationRepo, IVatRepository vatRepo, ISanitationFreeBenefitRepository saniFreeRepo)
        {
            _personTypeRepo = personRepo ?? throw new ArgumentNullException(nameof(personRepo));
            _sanitationRepo = sanitationRepo ?? throw new ArgumentNullException(nameof(sanitationRepo));
            _vatRepo = vatRepo ?? throw new ArgumentNullException(nameof(vatRepo)); ;
            _saniFreeRepo = saniFreeRepo ?? throw new ArgumentNullException(nameof(saniFreeRepo));

        }
        public SanitationOutDto CalculateSanitation(SanitationIn inputObject)
        {
            decimal sanitationCharge = 0;
            decimal indigentFreeKl = 0;
            decimal overrallConsumedKl = 0;
            decimal SanitationChargeAmountIncVat = 0;
            decimal inclusiveStepSanitationExVat = 0;
            decimal inclusiveStepSanitationIncVat = 0;
            decimal chargeAmountInclVat = 0;
            decimal sanitationChargeInVat = 0;
            decimal previousMax = 0;

            try
            {
                if (inputObject.PersonType == PersonTypeEnum.Indigent)
                {
                    var salitationlist = _sanitationRepo.GetAll().Where(x => x.PersonTypeId == (int)PersonTypeEnum.Indigent).ToList();
                    foreach (var saniItem in salitationlist)
                    {
                        if (inputObject.Consumption.IsBetweenSanitation((decimal)saniItem.MinConstumptValue, (decimal)saniItem.MaxConstumptValue))
                        {
                            sanitationCharge = (decimal)saniItem.ChargeAmountExVat;
                            break;
                        }

                    }
                    foreach (var saniFreeItem in _saniFreeRepo.GetAll())
                    {
                        if (inputObject.PropertyValue.IsBetween((decimal)saniFreeItem.PropertyMinValue, (decimal)saniFreeItem.PropertyMaxValue))
                        {
                            indigentFreeKl = saniFreeItem.FreeConsumption;
                            overrallConsumedKl = inputObject.Consumption - indigentFreeKl;
                            if (overrallConsumedKl <= 0)
                            {
                                overrallConsumedKl = inputObject.Consumption;
                            }
                            break;
                        }
                        if (saniFreeItem.FreeConsumption > inputObject.Consumption)
                        {
                            sanitationCharge = 0;
                        }
                    }
                    SanitationChargeAmountIncVat = sanitationCharge + (sanitationCharge * (_vatRepo.GetAll().Where(x => x.Year == DateTime.Now.Year).FirstOrDefault().PercentageValue) / 100);

                    //}

                }
                else
                {
                    var salitationlist = _sanitationRepo.GetAll().Where(x => x.PersonTypeId != (int)PersonTypeEnum.Indigent).ToList();
                    foreach (var sanLst in salitationlist)
                    {

                        if (inputObject.Consumption >= sanLst.MaxConstumptValue)
                        {
                            inclusiveStepSanitationExVat = inclusiveStepSanitationExVat + (sanLst.ChargeAmountExVat * sanLst.MaxConstumptValue);

                            previousMax = sanLst.MaxConstumptValue;
                            continue;
                        }

                        if (inputObject.Consumption.IsBetweenSanitation((decimal)sanLst.MinConstumptValue, (decimal)sanLst.MaxConstumptValue))
                        {

                            overrallConsumedKl = inputObject.Consumption - previousMax;
                            sanitationCharge = (decimal)sanLst.ChargeAmountExVat * overrallConsumedKl;

                            break;

                        }



                    }
                    SanitationChargeAmountIncVat = sanitationCharge + (sanitationCharge * (_vatRepo.GetAll().Where(x => x.Year == DateTime.Now.Year).FirstOrDefault().PercentageValue) / 100);

                    return new SanitationOutDto
                    {
                        ChargeAmountExVat = sanitationCharge + inclusiveStepSanitationExVat,
                        ChargeAmountInclVat = (sanitationCharge + inclusiveStepSanitationExVat ) * ((_vatRepo.GetAll().Where(x => x.Year == DateTime.Now.Year).FirstOrDefault().PercentageValue+100)/100)
                    };


                }



                return new SanitationOutDto
                {
                    ChargeAmountExVat = (overrallConsumedKl * sanitationCharge) + inclusiveStepSanitationExVat,
                    ChargeAmountInclVat = overrallConsumedKl * SanitationChargeAmountIncVat
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
