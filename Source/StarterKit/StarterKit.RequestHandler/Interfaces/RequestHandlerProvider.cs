using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarterKit.RequestHandler.Interfaces
{
    public class RequestHandlerProvider : IRequestHandlerProvider
    {
        public async Task<TResponse> ProcessRequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var handler = ServiceLocator.Current.GetInstance(typeof(IRequestHandler<TRequest, TResponse>));
            if (handler == null)
                throw new NotImplementedException("Cannot resolve the RequestHandler for " + typeof(TRequest).FullName);

            return await ((IRequestHandler<TRequest, TResponse>)handler).ProcessRequestAsync(request);
        }
    }
}
