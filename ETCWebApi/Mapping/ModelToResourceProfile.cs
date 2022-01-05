using AutoMapper;
using ETCWebApi.Domain.models;
using ETCWebApi.Domain.Models;
using ETCWebApi.Domain.Models.Query;
using ETCWebApi.Domain.Security.Tokens;
using ETCWebApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETCWebApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            //CreateMap<Notice, NoticeResource>().ReverseMap(); (here reverse map helps to map for both model to resource and resource to model
            CreateMap<Notice, NoticeResource>().ReverseMap();
            CreateMap<Contact, ContactResource>();
            CreateMap<User, UserResource>();
            CreateMap<AccessToken, AccessTokenResource>()
                .ForMember(a => a.AccessToken, opt => opt.MapFrom(a => a.Token))
                .ForMember(a => a.RefreshToken, opt => opt.MapFrom(a => a.RefreshToken.Token))
                .ForMember(a => a.Expiration, opt => opt.MapFrom(a => a.Expiration));
        }
    }
}
