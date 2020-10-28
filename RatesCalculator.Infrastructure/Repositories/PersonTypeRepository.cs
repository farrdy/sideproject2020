
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class PersonTypeRepository : EntityBaseRepository<PersonType>, IPersonTypeRepository
    {
        public PersonTypeRepository(RatesTariffsContext context): base(context)
        { }
    }
}
