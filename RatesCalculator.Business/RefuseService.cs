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
    public class RefuseService : IRefuseService
    {
        private IRefuseRepository _refuseRepo = null;
        private IRefuseRebatesRepository _refuserebates = null;
        private IRefuseRebatesIndigentRepository _refuse_rebates_indigent = null;
        private IPropertyValueRefuseRebatesRepository propertyValueRefuseRebates = null;
        private IPersonTypeRepository personTypeRebates = null;
        private IRefuseResidentialTypeRepository _residentailType = null;
        private IVatRepository _vatRepo = null;
        public RefuseService(IRefuseRepository refuserepo,
            IRefuseRebatesRepository refrebatesRepo,
            IRefuseRebatesIndigentRepository indigentRebatesRepo,
            IPropertyValueRefuseRebatesRepository propertyvalueRebatesRepo,
           IRefuseResidentialTypeRepository residentailType, IVatRepository vatrepo)
        {
            _refuseRepo = refuserepo ?? throw new ArgumentNullException(nameof(refuserepo));
            _refuserebates = refrebatesRepo ?? throw new ArgumentNullException(nameof(refrebatesRepo));
            _refuse_rebates_indigent = indigentRebatesRepo ?? throw new ArgumentNullException(nameof(indigentRebatesRepo));
            propertyValueRefuseRebates = propertyvalueRebatesRepo ?? throw new ArgumentNullException(nameof(propertyvalueRebatesRepo));
            _residentailType = residentailType ?? throw new ArgumentNullException(nameof(residentailType));
            _vatRepo = vatrepo ?? throw new ArgumentNullException(nameof(vatrepo));
        }
        public RefuseOutDto CalculateRefuse(RefuseIn inputObject)
        {
            decimal propertyValueRebate = 0;
            decimal indigentRebate = 0;
            decimal basicAmountExVat = 0;
            decimal basicAmountIncVat = 0;
            decimal ResultAmount = 0;
            int refuseFrequency = 1;
            decimal maximumPropertyValueRebate = 0;
            try
            {
                foreach (var item in propertyValueRefuseRebates.GetAll())
                {
                    if (inputObject.PropertyValue.IsBetween((decimal)item.PropertyMinValue, (decimal)item.PropertyMaxValue))
                    {
                        propertyValueRebate = (decimal)item.RebatePercent;
                        break;
                    }


                }
                var maximumPropertyRebate = propertyValueRefuseRebates.GetAll().LastOrDefault();
                if (maximumPropertyRebate != null && (maximumPropertyRebate.PropertyMaxValue < inputObject.PropertyValue))
                {
                    propertyValueRebate = maximumPropertyRebate.RebatePercent;


                }



                if (inputObject.PersonType == PersonTypeEnum.Indigent)
                {
                    foreach (var item in _refuse_rebates_indigent.GetAll())
                    {
                        if (inputObject.Income.IsBetween((decimal)item.MinIncome, (decimal)item.MaxIncome))
                        {
                            indigentRebate = (decimal)item.RebatePercentage;
                            break;
                        }
                    }
                }
                refuseFrequency = Convert.ToInt32(_residentailType.GetAll().Where(x => x.ResidentialType.Equals(inputObject.PropertyType.ToString())).FirstOrDefault().RefuseFrequencyWeekly);
                basicAmountIncVat = (decimal)_refuseRepo.GetAll().Where(x => x.Year == DateTime.Now.Year).FirstOrDefault().ChargeAmountIncVat;
                basicAmountExVat = (decimal)_refuseRepo.GetAll().Where(x => x.Year == DateTime.Now.Year).FirstOrDefault().ChargeAmountExVat;

                var propRebateIncVat = propertyValueRebate != 0 ? inputObject.NumberOfBins * basicAmountIncVat * (propertyValueRebate / 100) : 0;
                var indRebateInVat = indigentRebate != 0 ? inputObject.NumberOfBins * basicAmountIncVat * (indigentRebate / 100) : 0;


                var resultInVat = indigentRebate > 0 ? indRebateInVat : propRebateIncVat;



                var propRebateExVat = propertyValueRebate != 0 ? inputObject.NumberOfBins * basicAmountExVat * (propertyValueRebate / 100) : 0;
                var indRebateExVat = indigentRebate != 0 ? inputObject.NumberOfBins * basicAmountExVat * (indigentRebate / 100) : 0;
                var resultExVat = basicAmountExVat - (indRebateExVat > 0 ? indRebateExVat : propRebateExVat);

                if (inputObject.PersonType == PersonTypeEnum.Indigent)
                {
                    if (inputObject.NumberOfBins > 1)
                    {
                        resultExVat = resultExVat +((inputObject.NumberOfBins-1)* basicAmountExVat);
                    }
                    return new RefuseOutDto
                    {
                        ChargeAmountExVat = resultExVat,
                        ChargeAmountIncVat = resultExVat * ((_vatRepo.GetAll().Where(x => x.Year == DateTime.Now.Year).FirstOrDefault().PercentageValue + 100) / 100)

                    };
                }
                else
                {


                    if (inputObject.NumberOfBins > 1) {

                        basicAmountExVat = basicAmountExVat * inputObject.NumberOfBins;
                    }

                    return new RefuseOutDto
                    {
                        ChargeAmountExVat = basicAmountExVat,
                        ChargeAmountIncVat = basicAmountExVat * ((_vatRepo.GetAll().Where(x => x.Year == DateTime.Now.Year).FirstOrDefault().PercentageValue + 100) / 100)

                    };

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
