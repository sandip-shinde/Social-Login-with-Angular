using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.RequestValidator.Interfaces
{
    public interface IRequestValidatorProvider
    {
        IRequestValidator<TRequest> GetValidator<TRequest>()
            where TRequest : class;
    }
}
