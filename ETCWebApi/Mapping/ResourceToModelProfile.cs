using AutoMapper;
using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Models;
using ETCWebApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<NewNoticeSavingResource, Notice>();
            CreateMap<ContactResource, Contact>();
            CreateMap<NewUserResource, User>();
        }
    }
}
