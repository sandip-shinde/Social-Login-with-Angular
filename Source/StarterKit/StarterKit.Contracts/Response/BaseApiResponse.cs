using StarterKit.Contracts.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.Contracts.Response
{
    public class BaseResponse
    {
        [JsonIgnore]
        public ApiError Error { get; private set; }

        [JsonIgnore]
        public bool IsSuccess { get; set; }

        public BaseResponse(string errorCode)
        {
            if (errorCode != null && errorCode != "")
            {
                Error = new ApiError
                {
                    ErrorCode = errorCode,
                    ErrorMessage = ApiErrorCodes.GetErrorMessage(errorCode)
                };

                IsSuccess = false;
            }
            else IsSuccess = true;
        }
    }
}
