using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.Contracts.Request
{
    public class AuthenticationRequest : BaseApiRequest
    {
        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
