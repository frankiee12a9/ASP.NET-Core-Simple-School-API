using SchoolApiSrc.Models;
using SchoolApiSrc.DTOs.CourseDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using AutoMapper;
using SchoolApiSrc.DTOs.AppAuthDTO;

namespace SchoolApi.Profiles
{
    public class AppAuthProfile : Profile
    {
        public AppAuthProfile()
        {
            CreateMap<AppLoginInfo, AppRegisterDTO>()
                .ForMember(dest => dest.Username,
                        opts => opts.MapFrom(src => src.Username))
                .ForMember(dest => dest.UserType,
                        opts => opts.MapFrom(src => src.UserType))
                .ForMember(dest => dest.Password,
                        opts => opts.MapFrom(src => src.Password))
                .ReverseMap();

            CreateMap<AppLoginInfo, UserAppAuthInfoDTO>()
                .ForMember(dest => dest.Id,
                        otps => otps.MapFrom(src => src.AppLoginId))
                .ForMember(dest => dest.Username,
                        opts => opts.MapFrom(src => src.Username))
                .ForMember(dest => dest.UserType,
                        opts => opts.MapFrom(src => src.UserType))
                .ForMember(dest => dest.Password,
                        opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.HashedPassword,
                        opts => opts.MapFrom(src => src.HashedPassword))
                .ReverseMap();

            CreateMap<AppLoginInfo, AppLoginDTO>()
                .ForMember(dest => dest.Username,
                        opts => opts.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password,
                    opts => opts.MapFrom(src => src.Password))
                .ForMember(dest => dest.JwtKey,
                    opts => opts.MapFrom(src => src.JwtKey))
                .ReverseMap();
        }
    }
}