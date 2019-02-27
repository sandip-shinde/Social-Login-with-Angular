using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Request
{
    public class UserRegisterRequest : BaseApiRequest
    {
        public UserRegisterRequest() { }

        [JsonProperty(PropertyName = "firstName")]
        [Required]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        [Required]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "userName")]
        [Required]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "password")]
        [Required]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        [Required]
        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }
        [Required]
        [MaxLength(10)]
        [JsonProperty(PropertyName = "primaryContact")]
        public string PrimaryContact { get; set; }
        [JsonProperty(PropertyName = "secondaryContact")]
        public string SecondaryContact { get; set; }
    }
}