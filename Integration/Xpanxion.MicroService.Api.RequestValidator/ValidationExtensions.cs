using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Xpanxion.MicroService.Api.Integration.Contracts.Types;

namespace Xpanxion.MicroService.Api.RequestValidator
{
    public static class ValidationExtensions
    {
        public static Integration.Contracts.Types.ValidationResult DoFluentValidations(this object request)
        {
            Integration.Contracts.Types.ValidationResult result = null;
            ApiError apiError = null;
            string validationMessage = string.Empty;
            ValidationContext validationContext = new ValidationContext(request, null, null);
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

            if (!string.IsNullOrEmpty(validationMessage))
            {
                apiError = new ApiError(Common.Enums.ErrorCode.InvalidRequest);
                apiError.Message = validationMessage;
                result = new Integration.Contracts.Types.ValidationResult {
                    Error = apiError
                };
            }

            return result;

        }
    }
}
