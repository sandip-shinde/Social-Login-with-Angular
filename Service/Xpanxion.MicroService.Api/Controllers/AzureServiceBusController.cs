using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Xpanxion.MicroService.Api.Integration.Contracts;
using Xpanxion.MicroService.Api.Integration.Contracts.Request.Cloud;
using Xpanxion.MicroService.Api.Integration.Contracts.Response.Cloud;
using Xpanxion.MicroService.Api.Integration.RequestHandler.Interfaces;


namespace Xpanxion.MicroService.Api.Controllers
{
    [Route("api/[controller]")]
    public class AzureServiceBusController : BaseApiController
    {
        private readonly AppSettings _appSettings;
        public AzureServiceBusController(IRequestHandlerProvider requestHandlerProvider, IOptions<AppSettings> appSettings) : base(requestHandlerProvider)
        {
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> SendMessage([FromBody]ServiceBusPostApiRequest apiRequest)
        {
            var request = new ServiceBusPostRequest
            {
                ConnectionString = _appSettings.AzureServiceBusConnectionString,
                TopicName = apiRequest.TopicName,
                Subscribers = apiRequest.Subscribers,
                Message = apiRequest.Message
            };
            var result = await RequestHandler.ProcessRequestAsync<ServiceBusPostRequest, ServiceBusPostResponse>(request);
            return Ok(result);
        }
    }
}