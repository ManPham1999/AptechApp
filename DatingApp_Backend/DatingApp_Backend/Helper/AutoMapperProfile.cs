using System;
using System.Linq;
using AutoMapper;
using DatingApp.Entities;
using DatingApp_Backend.DTO;
using DatingApp_Backend.Entities;

namespace DatingApp_Backend.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, MemberDTO>().ForMember(dest => dest.PhotoUrl , opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<Photo, PhotoDTO>();
            CreateMap<MemberDTO, AppUser>();
        }
    }
}
