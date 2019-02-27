using System;
using System.Collections.Generic;
using System.Text;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;
using Xpanxion.MicroService.Api.Integration.Contracts.Types;
using Xpanxion.MicroService.Api.RequestValidator.Interfaces;

namespace Xpanxion.MicroService.Api.RequestValidator
{
    public class UserGetRequestValidator : IRequestValidator<UserGetRequest>
    {
        public ValidationResult Validate(UserGetRequest request)
        {
            return null;
        }
    }
}
