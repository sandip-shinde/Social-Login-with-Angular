using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xpanxion.MicroService.Api.CloudServices.Azure.Interfaces;
using Xpanxion.MicroService.Api.Common.Enums;
using Xpanxion.MicroService.Api.Integration.Contracts.Request.Cloud;
using Xpanxion.MicroService.Api.Integration.Contracts.Response.Cloud;
using Xpanxion.MicroService.Api.Integration.Contracts.Types;
using Xpanxion.MicroService.Api.RequestValidator.Interfaces;

namespace Xpanxion.MicroService.Api.Integration.RequestHandler.CloudHandlers
{
    public class ServiceBusPostRequestHandler : BaseRequestHandler<ServiceBusPostRequest, ServiceBusPostResponse>
    {
        readonly IServiceBusManager _serviceBusManager;
        public ServiceBusPostRequestHandler(IServiceBusManager serviceBusManager, IMapper mapper,
            IRequestValidator<ServiceBusPostRequest> requestValidator) : base(mapper, requestValidator)
        {
            _serviceBusManager = serviceBusManager;
        }

        protected override Task<ServiceBusPostResponse> HandleRequestAsync(ServiceBusPostRequest request)
        {
            var response = new ServiceBusPostResponse();
            var messageResponse = _serviceBusManager.SendMessages(request.Message, request.ConnectionString, request.TopicName);
            if (messageResponse.Result)
            {
                response.Error = null;
            }
            else
                response.Error = new ApiError(ErrorCode.MessageNotSent);
            return Task.FromResult<ServiceBusPostResponse>(response);
        }
    }
}
