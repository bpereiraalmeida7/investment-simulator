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
  public interface IInvestmentService
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="months"></param>
    /// <returns></returns>
    decimal CalculateTaxIR(decimal amount, int months);
  }
}
