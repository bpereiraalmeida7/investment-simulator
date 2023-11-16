using InvestimentSimulator.WebAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestimentSimulator.WebAPI.Core.Interfaces
{
  /// <summary>
  /// 
  /// </summary>
  public interface ICdbInvestimentService
  {
        /// <summary>
        /// Cálculo de investimento
        /// </summary>
        /// <param name="investment"></param>
        /// <returns></returns>
        InvestmentResponse CalculateInvestment(Investment investment);
  }
}
