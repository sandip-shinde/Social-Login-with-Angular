using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Xpanxion.MicroService.Api.Common;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;
using Xpanxion.MicroService.Api.Integration.Contracts.Types;
using Xpanxion.MicroService.Api.RequestValidator.Interfaces;

namespace Xpanxion.MicroService.Api.RequestValidator
{
    public class UserRegisterRequestValidator : IRequestValidator<UserRegisterRequest>
    {
        public Integration.Contracts.Types.ValidationResult Validate(UserRegisterRequest request)
        {
            // TODO : Add Contract valudations or else return null

            return null;
        }
    }
}
