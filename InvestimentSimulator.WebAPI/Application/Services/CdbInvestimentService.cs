using InvestimentSimulator.WebAPI.Core.Entities;
using InvestimentSimulator.WebAPI.Core.Interfaces;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestimentSimulator.WebAPI.Application.Services
{
  /// <summary>
  /// Service do tipo de investimento CDB
  /// </summary>
  public class CdbInvestimentService : InvestmentService, ICdbInvestimentService
  {
        /// <summary>
        /// Cálculo do investimento
        /// </summary>
        /// <param name="investment"></param>
        /// <returns></returns>
        public InvestmentResponse CalculateInvestment(Investment investment)
        {
            decimal cdi = 0.009m;
            decimal tb = 1.08m;

            decimal finalValue = investment.Amount;

            for (int i = 0; i < investment.Months; i++)
            {
                finalValue *= (1 + (cdi * tb));
            }

            decimal income = finalValue - investment.Amount;

            return new InvestmentResponse
            {
                GrossAmount = Math.Round(finalValue, 2),
                NetAmount = Math.Round(finalValue - CalculateTaxIR(income, investment.Months), 2)
            };
        }
  }
}