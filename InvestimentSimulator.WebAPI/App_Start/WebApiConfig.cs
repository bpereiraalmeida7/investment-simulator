using SimpleInjector.Integration.Web;
using SimpleInjector;
using System.Web.Http;
using InvestimentSimulator.WebAPI.Core.Interfaces;
using InvestimentSimulator.WebAPI.Application.Services;
using SimpleInjector.Integration.WebApi;

namespace InvestimentSimulator.WebAPI
{
    /// <summary>
    /// Configurações WebAPI
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
            config.EnableCors();

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<ICdbInvestimentService, CdbInvestimentService>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(config);
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
