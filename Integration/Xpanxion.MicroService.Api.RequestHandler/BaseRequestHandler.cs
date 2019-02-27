using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xpanxion.MicroService.Api.Integration.Contracts.Types;
using Xpanxion.MicroService.Api.Integration.RequestHandler.Interfaces;
using Xpanxion.MicroService.Api.RequestValidator;
using Xpanxion.MicroService.Api.RequestValidator.Interfaces;

namespace Xpanxion.MicroService.Api.Integration.RequestHandler
{
    public abstract class BaseRequestHandler<TRequest,TResponse>: IRequestHandler<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        public readonly IMapper Mapper;
        public readonly IRequestValidator<TRequest> Validator;

        public BaseRequestHandler(
            IMapper mapper,
            IRequestValidator<TRequest> validator) {
            this.Mapper = mapper;
            this.Validator = validator;
        }

        public Task<TResponse> ProcessRequestAsync(TRequest request)
        {
            try
            {
                if (this.Validator != null)
                    this.ValidateRequest(request);

                return HandleRequestAsync(request);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected abstract Task<TResponse> HandleRequestAsync(TRequest request);

        private void ValidateRequest(TRequest request)
        {
            ValidationResult fluentValidationResult = request.DoFluentValidations();
            if (fluentValidationResult!= null && !fluentValidationResult.IsValid)
            {
                throw new Exception(fluentValidationResult.Error.Message);
            }

            ValidationResult contractValidationResult = ((IRequestValidator<TRequest>)this.Validator).Validate(request);
            if (contractValidationResult != null && !contractValidationResult.IsValid)
            {
                throw new Exception(contractValidationResult.Error.Message);
            }

        }

    }
}
