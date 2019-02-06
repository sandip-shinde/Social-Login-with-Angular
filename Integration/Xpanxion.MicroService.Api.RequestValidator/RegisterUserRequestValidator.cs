using System;
using System.Collections.Generic;
using System.Text;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;
using Xpanxion.MicroService.Api.Integration.Contracts.Types;
using Xpanxion.MicroService.Api.RequestValidator.Interfaces;

namespace Xpanxion.MicroService.Api.RequestValidator
{
    public class RegisterUserRequestValidator : IRequestValidator<RegisterUserRequest>
    {
        public ValidationResult Validate(RegisterUserRequest trequest)
        {

            return new ValidationResult
            {
                Error = null
            };

            // TODO Thorow exception from here 
            //throw new NotImplementedException();
        }
    }
}
