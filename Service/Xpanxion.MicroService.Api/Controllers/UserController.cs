using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;
using Xpanxion.MicroService.Api.Integration.Contracts.Response;
using Xpanxion.MicroService.Api.Integration.RequestHandler.Interfaces;

namespace Xpanxion.MicroService.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        public UserController(IRequestHandlerProvider requestHandlerProvider) : base(requestHandlerProvider)
        {
        }

        [HttpPost]
        [Route("Register")]
        public async Task<HttpResponseMessage> Register(RegisterUserRequest request)
        {
            var result = await this.RequestHandler.ProcessRequestAsync<RegisterUserRequest, RegisterUserResponse>(request);

            if (result.IsSuccess)
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            else
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);

        }

    }
}
