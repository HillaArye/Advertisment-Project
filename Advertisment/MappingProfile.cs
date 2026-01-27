using Advertisment.Core.Entities;
using Advertisment.Models;
using AutoMapper;

namespace Advertisment
{
    public class MappingProfile:Profile
    {
        public MappingProfile() { 
            CreateMap<Adver,AdverPostPutModel>().ReverseMap();
            CreateMap<Advertiser,AdvertiserPostPutModel>().ReverseMap();
            CreateMap<Core.Entities.Route,RoutePostPutModel>().ReverseMap();
        
        }  
    }
}
