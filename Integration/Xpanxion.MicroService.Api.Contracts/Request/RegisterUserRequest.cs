using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Request
{
    public class RegisterUserRequest: BaseApiRequest
    {
        public RegisterUserRequest() { }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }
        [JsonProperty(PropertyName = "primaryContact")]
        public string PrimaryContact { get; set; }
        [JsonProperty(PropertyName = "secondaryContact")]
        public string SecondaryContact { get; set; }
    }
}