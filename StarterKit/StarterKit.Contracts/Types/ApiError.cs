using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.Contracts.Types
{
    public class ApiError
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("message")]
        public string ErrorMessage { get; set; }
    }
}
