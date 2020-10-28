using RatesCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RatesCalculator.Service.Interfaces
{
   public interface IRefuseService
    {
        RefuseOutDto CalculateRefuse(RefuseIn input);
    }
}
