using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;
using Xpanxion.MicroService.Api.Integration.Contracts.Types;
using Xpanxion.MicroService.Api.RequestValidator.Interfaces;

namespace Xpanxion.MicroService.Api.RequestValidator
{
    public class RegisterUserRequestValidator : IRequestValidator<RegisterUserRequest>
    {
        public Integration.Contracts.Types.ValidationResult Validate(RegisterUserRequest request)
        {
            string validationMessage = string.Empty;
            ValidationContext validationContext = new ValidationContext(request,null,null);
            List<System.ComponentModel.DataAnnotations.ValidationResult> validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            bool isValidRequest = Validator.TryValidateObject(request, validationContext, validationResults, true);
            
            if (!isValidRequest)
            {
                foreach (System.ComponentModel.DataAnnotations.ValidationResult vr in validationResults)
                {
                    validationMessage = string.Format("{0}Member Name :{0} {1} {2}", 
                                                        validationMessage, 
                                                        vr.MemberNames.First(), 
                                                        validationMessage, 
                                                        vr.ErrorMessage, 
                                                        Environment.NewLine);
                }
            }
            if (!isValidRequest)
            {
                ApiError apiError = new ApiError(Common.Enums.ErrorCode.InvalidRequest);
                apiError.Message = validationMessage;
                return new Integration.Contracts.Types.ValidationResult
                {
                    Error = apiError
                };
            }
            else
                return new Integration.Contracts.Types.ValidationResult
                {
                    Error = null
                };

            // TODO Thorow exception from here 
            //throw new NotImplementedException();
        }
    }
}
