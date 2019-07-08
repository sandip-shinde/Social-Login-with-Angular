using Newtonsoft.Json;
using Xpanxion.MicroService.Api.Integration.Contracts.Types;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Response
{
    public class BaseApiResponse
    {
        [JsonProperty(PropertyName = "error")]
        public ApiError Error { get; set; }

        [JsonProperty(PropertyName = "isSuccess")]
        public bool IsSuccess
        {
            get
            {
                return this.Error == null;
            }
        }
    }
}
