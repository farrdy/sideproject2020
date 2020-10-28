using Microsoft.EntityFrameworkCore.Query.Internal;
using RatesCalculator.Data;
using RatesCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Interfaces
{
    public interface IRefuseRepository : IEntityBaseRepository<Refuse> { }

    public interface IRefuseRebatesRepository : IEntityBaseRepository<RefuseRebates> { }

    public interface IRefuseRebatesIndigentRepository : IEntityBaseRepository<RefuseRebatesIndigent> { }
    public interface IAuditEntityRepository : IEntityBaseRepository<AuditEntity> { }

    public interface IAuditEntityFieldRepository : IEntityBaseRepository<AuditEntityField> { }

    public interface ICentInRandRepository : IEntityBaseRepository<CentInRand> { }

    public interface IElectricityRepository : IEntityBaseRepository<Electricity> { }

    public interface IElectricityFreeBenefitRepository : IEntityBaseRepository<ElectricityFreeBenefit> { }

    public interface IPersonTypeRepository : IEntityBaseRepository<PersonType> { }

    public interface IPropertyRebatesRepository : IEntityBaseRepository<PropertyRebates> {
        //PropertyRebates getAll();
    }

    public interface IPropertyValueRefuseRebatesRepository : IEntityBaseRepository<PropertyValueRefuseRebates> { }

    public interface IRefuseResidentialTypeRepository : IEntityBaseRepository<RefuseResidentialType> { }

    public interface IResidentWasteCollectionRepository : IEntityBaseRepository<ResidentWasteCollection> { }

    public interface IRoleRepository : IEntityBaseRepository<Role> { }

    public interface ISanitationRepository : IEntityBaseRepository<Sanitation> { }
    public interface ISanitationFreeBenefitRepository : IEntityBaseRepository<SanitationFreeBenefit> { }

    public interface IWaterRepository : IEntityBaseRepository<Water> { }

    public interface IWaterMeterRepository : IEntityBaseRepository<WaterMeter> { }

    public interface IWaterFixedChargesRepository : IEntityBaseRepository<WaterFixedCharges> { }

    public interface IIndigentIncomeRepository : IEntityBaseRepository<IndigentIncomeLevel> { }
    public interface IIncomeDisbaledPensionerRepository : IEntityBaseRepository<PensionerDisabledIncome> { }
    public interface IWaterPropertyBenefitRepository : IEntityBaseRepository<WaterPropertyBenefit> { }
    public interface IVatRepository : IEntityBaseRepository<Vat> { }



}
