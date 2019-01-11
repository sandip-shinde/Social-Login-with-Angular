using System;
using System.Threading.Tasks;
using Xpanxion.MicroService.Api.Integration.RequestHandler.Interfaces;

namespace Xpanxion.MicroService.Api.Integration.RequestHandler
{
    public class RequestHandlerProvider : IRequestHandlerProvider
    {
        private IServiceProvider ServiceProvider { get; }
        public RequestHandlerProvider(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }
        public async Task<TResponse> ProcessRequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var handler = this.ServiceProvider.GetService(typeof(IRequestHandler<TRequest, TResponse>));
            if (handler == null)
                throw new NotImplementedException("Cannot resolve the RequestHandler for " + typeof(TRequest).FullName);

            return await ((IRequestHandler<TRequest, TResponse>)handler).ProcessRequestAsync(request);
        }
    }
}
