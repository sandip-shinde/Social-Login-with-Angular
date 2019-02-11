using AutoMapper;
using System;
using Xpanxion.MicroService.Api.DataAccess.Entities;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;

namespace Xpanxion.MicroService.Api.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;

            CreateMap<RegisterUserRequest, User>();
        }
    }
}
