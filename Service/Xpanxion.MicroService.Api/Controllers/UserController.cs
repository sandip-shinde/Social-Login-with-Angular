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
        public async Task<IActionResult> Register([FromBody]UserRegisterRequest request)
        {
            var result = await this.RequestHandler.ProcessRequestAsync<UserRegisterRequest, UserRegisterResponse>(request);

            return Ok(result);    
        }

        [HttpPost]
        [Route("GetByName")]
        public IActionResult Get([FromBody]UserGetRequest request)
        {
            return Ok(this.RequestHandler.ProcessRequestAsync<UserGetRequest, UserGetResponse>(request).Result);
            
        }
    }
}
