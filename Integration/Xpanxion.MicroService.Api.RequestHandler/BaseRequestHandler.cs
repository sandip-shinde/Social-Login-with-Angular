using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.RequestHandler
{
    public class BaseRequestHandler
    {
        public readonly IMapper Mapper;

        public BaseRequestHandler(IMapper mapper) {
            this.Mapper = mapper;
        }
    }
}
