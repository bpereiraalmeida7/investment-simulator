using InvestimentSimulator.WebAPI.Application.Services;
using InvestimentSimulator.WebAPI.Core.Entities;
using InvestimentSimulator.WebAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InvestimentSimulator.WebAPI.Controllers
{
    /// <summary>
    /// Controller do CDBInvestment
    /// </summary>
    [Route("api/")]
    public class CdbInvestmentController : ApiController
    {
        private readonly ICdbInvestimentService _cdbInvestmentService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cdbInvestmentService"></param>
        public CdbInvestmentController(ICdbInvestimentService cdbInvestmentService)
        {
            _cdbInvestmentService = cdbInvestmentService;
        }

        /// <summary>
        /// Solicitar cálculo de investimento CDB
        /// </summary>
        /// <param name="investmentRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("cdbCalculate")]
        public IHttpActionResult Post([FromBody] Investment investmentRequest)
        {
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(investmentRequest, new ValidationContext(investmentRequest), validationResults, true);
            if (!isValid)
            {
                var errorMessage = string.Join(", ", validationResults.Select(result => result.ErrorMessage));
                return Content(HttpStatusCode.BadRequest, errorMessage);
            }
             
            InvestmentResponse investmentResponse 
                = _cdbInvestmentService.CalculateInvestment(investmentRequest);

            return Ok(investmentResponse);
        }   
    }
}
