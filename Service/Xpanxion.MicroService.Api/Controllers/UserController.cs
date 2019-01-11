using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xpanxion.MicroService.Api.Integration.RequestHandler.Interfaces;

namespace Xpanxion.MicroService.Api.Controllers
{
    public class UserController : BaseApiController
    {
        public UserController(IRequestHandlerProvider requestHandlerProvider) : base(requestHandlerProvider)
        {
        }
    }
}
