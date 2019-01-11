using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xpanxion.MicroService.Api.Integration.RequestHandler.Interfaces
{
    public interface IRequestHandlerProvider
    {
        Task<TResponse> ProcessRequestAsync<TRequest, TResponse>(TRequest request)
           where TRequest : class
           where TResponse : class;
    }
}
