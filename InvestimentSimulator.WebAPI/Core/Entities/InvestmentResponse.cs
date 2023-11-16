using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestimentSimulator.WebAPI.Core.Entities
{
    /// <summary>
    /// Resultado do investimento
    /// </summary>
    public class InvestmentResponse
    {
        /// <summary>
        /// Valor Bruto
        /// </summary>
        [JsonProperty("grossAmount")]
        public decimal GrossAmount { get; set; }

        /// <summary>
        /// Valor liquido
        /// </summary>
        [JsonProperty("netAmount")]
        public decimal NetAmount { get; set; }
    }
}