using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Response
{
    public class RegisterUserResponse: BaseApiResponse
    {
        public RegisterUserResponse()
        {

        }

        [JsonProperty(PropertyName = "userID")]
        public string UserID { get; set; }

        
    }
}
