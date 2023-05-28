using AutoMapper;
using Social1.Models;
using Social1.ViewModel;

namespace Social1.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, AppUserVM>().ReverseMap();
            CreateMap<AppUser, UserVMP>().ReverseMap();
            CreateMap<Commant, CommantVM>().ReverseMap();
            CreateMap<Commant, CommantVMP>().ReverseMap();
            CreateMap<Post, PostVM>().ReverseMap();
            CreateMap<Post,PostVMP>().ReverseMap();
            
        }
    }
}
