using System;
using Xpanxion.MicroService.Api.RequestValidator.Interfaces;

namespace Xpanxion.MicroService.Api.RequestValidator
{
    public class RequestValidatorProvider : IRequestValidatorProvider
    {
        private IServiceProvider ServiceProvider { get; }

        public RequestValidatorProvider(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }
        
        public IRequestValidator<TRequest> GetValidator<TRequest>() 
            where TRequest : class
        {
            var validator = this.ServiceProvider.GetService(typeof(IRequestValidator<TRequest>));
            if (validator == null)
                throw new NotImplementedException("Cannot resolve the RequestValidator for " + typeof(TRequest).FullName);

            return (IRequestValidator<TRequest>)validator;
        }
    }
}
