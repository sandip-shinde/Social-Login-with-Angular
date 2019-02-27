using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Request
{
    public class UserGetRequest : BaseApiRequest
    {
        public UserGetRequest()
        {
        }

        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

    }
}
