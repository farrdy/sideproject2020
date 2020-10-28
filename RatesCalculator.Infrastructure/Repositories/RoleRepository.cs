
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class RoleRepository : EntityBaseRepository<Role>,IRoleRepository
    {

            public RoleRepository(RatesTariffsContext context) : base(context)
    {
    }
}
}

