using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.Contracts.Response
{
    public class AuthenticationResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "isAuthenticated")]
        public bool IsAuthenticated { get; set; } //todo : remove this property.

        [JsonProperty(PropertyName = "isValidUsername")]
        public bool IsValidUsername { get; set; }

        [JsonProperty(PropertyName = "resultCode")]
        public int ResultCode { get; set; }

        public AuthenticationResponse(string errorCode) : base(errorCode)
        {
        }
    }
}
