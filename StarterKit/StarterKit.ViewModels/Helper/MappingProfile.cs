using AutoMapper;
using StarterKit.Contracts.Entities;
using StarterKit.Contracts.Request;
using StarterKit.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKit.ViewModels.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            MapModelToRequest();
            MapRequestToEntity();
            MapEntityToResponse();
            MapResponseToModel();
        }

        private void MapModelToRequest()
        {
            CreateMap<LoginModel, AuthenticationRequest>();
        }

        private void MapRequestToEntity()
        {
            CreateMap<AuthenticationRequest, User>();
        }

        private void MapEntityToResponse()
        {

        }

        private void MapResponseToModel()
        {

        }
    }
}
