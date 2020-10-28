
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
   public  class ResidentWasteCollectionRepository: EntityBaseRepository<ResidentWasteCollection>, IResidentWasteCollectionRepository
    {
        public ResidentWasteCollectionRepository(RatesTariffsContext context) : base(context)
        {
        }
    }
}
