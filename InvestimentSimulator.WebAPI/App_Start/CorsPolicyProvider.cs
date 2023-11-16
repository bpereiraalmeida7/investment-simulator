using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Cors;
using System;
using System.Web.Http.Cors;
using System.Threading;

namespace InvestimentSimulator.WebAPI
{
    /// <summary>
    /// CorsPolicyProviderAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class CorsPolicyProviderAttribute : Attribute, ICorsPolicyProvider
    {
        private readonly CorsPolicy _policy;

        /// <summary>
        /// Provedor de politicas Cors
        /// </summary>
        public CorsPolicyProviderAttribute()
        {
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };

            _policy.Origins.Add("http://127.0.0.1:4200");
            _policy.Origins.Add("http://localhost:4200");
        }

        Task<CorsPolicy> ICorsPolicyProvider.GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}