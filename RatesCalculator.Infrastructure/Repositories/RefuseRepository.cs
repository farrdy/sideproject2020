
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Infrastructure.Repositories
{
   public  class RefuseRepository:EntityBaseRepository<Refuse>,IRefuseRepository
    {
        //private RatesTariffsContext _context;
        public RefuseRepository(RatesTariffsContext context)        : base(context)
        { }
    }
}
