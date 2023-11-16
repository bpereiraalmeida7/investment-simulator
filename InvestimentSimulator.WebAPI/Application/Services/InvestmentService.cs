using InvestimentSimulator.WebAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestimentSimulator.WebAPI.Application.Services
{
  /// <summary>
  /// Service Base de Investimento
  /// </summary>
  public class InvestmentService : IInvestmentService
  {
    /// <summary>
    /// Constructor
    /// </summary>
    protected InvestmentService() {}

    /// <summary>
    /// Cálculo de taxa IR
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="months"></param>
    /// <returns></returns>
    public decimal CalculateTaxIR(decimal amount, int months)
    {
      if (months <= 6)
        return amount * 0.225m;
      else if (months <= 12)
        return amount * 0.20m;
      else if (months <= 24)
        return amount * 0.175m;
      else
        return amount * 0.15m;
    }
  }
}