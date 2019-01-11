using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xpanxion.MicroService.Api.Integration.RequestHandler.Interfaces;

namespace Xpanxion.MicroService.Api.Controllers
{

    public class BaseApiController : Controller
    {
        public IRequestHandlerProvider RequestHandler;

        public BaseApiController(IRequestHandlerProvider requestHandlerProvider)
        {
            this.RequestHandler = requestHandlerProvider;
        }
    }
}
