using Advertisment.Core.DTOs;
using Advertisment.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Core
{
    internal class MappingProfile:Profile
    {
        public MappingProfile() { 
            CreateMap<Adver,AdverDTO>().ReverseMap();
            CreateMap<Advertiser,AdvertiserDTO>().ReverseMap(); 
            CreateMap<Route,RouteDTO>().ReverseMap();
        }
    }
}
