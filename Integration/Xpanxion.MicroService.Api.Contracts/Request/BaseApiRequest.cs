using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Request
{
    public class BaseApiRequest
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
