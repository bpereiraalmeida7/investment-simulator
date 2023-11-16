using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http.Cors;

namespace InvestimentSimulator.WebAPI
{
    /// <summary>
    /// CorsPolicyFactory
    /// </summary>
    public class CorsPolicyFactory : ICorsPolicyProviderFactory
    {
        readonly ICorsPolicyProvider _provider = new CorsPolicyProviderAttribute();

        /// <summary>
        /// Intermediador de politicas Cors
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
        {
            return _provider;
        }
    }
}