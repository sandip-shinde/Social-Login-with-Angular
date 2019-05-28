using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarterKit.RequestHandler.Interfaces
{
    public interface IRequestHandlerProvider
    {
        Task<TResponse> ProcessRequestAsync<TRequest, TResponse>(TRequest request)
           where TRequest : class
           where TResponse : class;
    }
}
