﻿
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
    public class RefuseRebatesIndigentRepository : EntityBaseRepository<RefuseRebatesIndigent>, IRefuseRebatesIndigentRepository
    {
        public RefuseRebatesIndigentRepository(RatesTariffsContext context): base(context)
        { 
        }
    }
}

