using Newtonsoft.Json;
using Xpanxion.MicroService.Api.Common.Enums;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Types
{
    public class ApiError
    {
        public ApiError(ErrorCode errorCode)
        {
            this.Code = errorCode;
        }

        [JsonProperty(PropertyName = "code")]
        public ErrorCode Code { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

    }
}
