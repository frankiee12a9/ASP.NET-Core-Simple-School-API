using AutoMapper;
using SchoolApiSrc.Models;
using SchoolApiSrc.DTOs.LecturerDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace SchoolApiSrc.Profiles
{
    public class LecturerProfile : Profile
    {

        public LecturerProfile()
        {
            CreateMap<Lecturer, LecturerReadDTO>()
                .ForMember(dest => dest.Name,
                        opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email,
                        opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.LecturerType,
                        opts => opts.MapFrom(src => src.LecturerType))
                .ForMember(dest => dest.AssignedCourses,
                        opts => opts.MapFrom(src => src.CourseAssignments.Count))
                .ReverseMap();

            CreateMap<Lecturer, LecturerCreateDTO>()
                .ForMember(dest => dest.Id,
                        opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name,
                        opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.LecturerType,
                           opts => opts.MapFrom(src => src.LecturerType))
                .ForMember(dest => dest.Email,
                            opts => opts.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<LecturerUpdateDTO, Lecturer>()
                .ForMember(dest => dest.Id,
                        opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name,
                        opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.LecturerType,
                        opts => opts.MapFrom(src => src.LecturerType))
                .ForMember(dest => dest.Email,
                        opts => opts.MapFrom(src => src.Email))
                .ReverseMap();


            CreateMap<JsonPatchDocument<LecturerUpdateDTO>, JsonPatchDocument<Lecturer>>();
            CreateMap<Operation<LecturerUpdateDTO>, Operation<Lecturer>>();
        }
    }
}