﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xpanxion.MicroService.Api.Common.Enums;
using Xpanxion.MicroService.Api.DataAccess.Entities;
using Xpanxion.MicroService.Api.DataAccess.Repository.Interfaces;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;
using Xpanxion.MicroService.Api.Integration.Contracts.Response;
using Xpanxion.MicroService.Api.Integration.Contracts.Types;
using Xpanxion.MicroService.Api.Integration.RequestHandler.Interfaces;

namespace Xpanxion.MicroService.Api.Integration.RequestHandler
{
    public class RegisterUserRequestHandler : BaseRequestHandler, IRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
        IUserRepository userRepository;

        public RegisterUserRequestHandler(IUserRepository userRepository, IMapper mapper) : base(mapper)
        {
            this.userRepository = userRepository;
        }

        public Task<RegisterUserResponse> ProcessRequestAsync(RegisterUserRequest request)
        {
            RegisterUserResponse response = new RegisterUserResponse();

            if (this.userRepository.RegisterNewUser(this.Mapper.Map<User>(request)))
                response.Error = null; 
            else
                response.Error = new ApiError(ErrorCode.UserAlreadyExists);

            return Task.FromResult<RegisterUserResponse>(response);
        }
    }
}
