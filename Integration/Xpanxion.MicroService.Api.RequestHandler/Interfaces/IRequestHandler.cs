using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xpanxion.MicroService.Api.Integration.RequestHandler.Interfaces
{
    public interface IRequestHandler<TRequest, TResponse>
       where TRequest : class
       where TResponse : class
    {
        Task<TResponse> ProcessRequestAsync(TRequest request);
    }
}
