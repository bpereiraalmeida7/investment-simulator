using System.Web.Http;
using WebActivatorEx;
using InvestimentSimulator.WebAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace InvestimentSimulator.WebAPI
{
    /// <summary>
    /// Configuração Swagger
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected SwaggerConfig() { }

        /// <summary>
        /// Register do Swagger
        /// </summary>
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "InvestimentSimulator.WebAPI");
                    })
                .EnableSwaggerUi(c =>{});
        }
    }
}
