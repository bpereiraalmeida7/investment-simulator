using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestimentSimulator.WebAPI.Core.Entities
{
    /// <summary>
    /// Investimento
    /// </summary>
    public class Investment
    {
        /// <summary>
        /// Valor inicial do investimento.
        /// </summary>
        [Required(ErrorMessage = "O campo 'investimento' é obrigatório.")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Número de meses do investimento.
        /// </summary>
        [Required(ErrorMessage = "O campo 'meses' é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo 'meses' deve ser maior que zero.")]
        public int Months { get; set; }
    }
}