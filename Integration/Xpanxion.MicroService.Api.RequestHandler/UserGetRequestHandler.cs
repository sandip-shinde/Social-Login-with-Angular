using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xpanxion.MicroService.Api.DataAccess.Entities;
using Xpanxion.MicroService.Api.DataAccess.Repository.Interfaces;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;
using Xpanxion.MicroService.Api.Integration.Contracts.Response;
using Xpanxion.MicroService.Api.Integration.RequestHandler.Interfaces;
using Xpanxion.MicroService.Api.RequestValidator.Interfaces;

namespace Xpanxion.MicroService.Api.Integration.RequestHandler
{
    public class UserGetRequestHandler : BaseRequestHandler<UserGetRequest, UserGetResponse>
    {
        IUserRepository userRepository;

        public UserGetRequestHandler(IUserRepository repository, IMapper mapper, IRequestValidator<UserGetRequest> requestValidator) : base(mapper, requestValidator)
        {
            this.userRepository = repository;
        }

        protected override Task<UserGetResponse> HandleRequestAsync(UserGetRequest request)
        {
            UserGetResponse response = new UserGetResponse();

            User user = this.userRepository.GetUserByUserName(request.UserName);

            if (user != null)
                response = this.Mapper.Map<User, UserGetResponse>(user);
            else
                response.Error = new Contracts.Types.ApiError(Common.Enums.ErrorCode.UserNotFound);

            return Task.FromResult<UserGetResponse>(response);
        }
    }
}
