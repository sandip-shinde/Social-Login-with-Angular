using AutoMapper;
using System;
using Xpanxion.MicroService.Api.DataAccess.Entities;
using Xpanxion.MicroService.Api.Integration.Contracts.Request;
using Xpanxion.MicroService.Api.Integration.Contracts.Response;

namespace Xpanxion.MicroService.Api.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            MapRequestToEntity();
            MapEntityToResponse();
        }

        private void MapRequestToEntity()
        {
            CreateMap<UserRegisterRequest, User>();
        }

        private void MapEntityToResponse()
        {
            CreateMap<User,UserGetResponse>();
        }

    }
}
