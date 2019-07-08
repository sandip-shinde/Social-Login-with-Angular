using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Xpanxion.MicroService.Api.Integration.Contracts;
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

    }
}