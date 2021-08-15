using AutoMapper;
using SchoolApiSrc.Models;
using SchoolApiSrc.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace SchoolApiSrc.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseReadDTO>()
                .ForMember(dest => dest.DepartmentName,
                           opts => opts.MapFrom(src => src.Department.DepartmentName))
                .ForMember(dest => dest.Enrollemnts,
                            opts => opts.MapFrom(src => src.CourseEnrollments.Count))
                .ForMember(dest => dest.LecturersNumber,
                            opts => opts.MapFrom(src => src.CourseAssignments.Count))
                .ReverseMap();

            CreateMap<Course, CourseCreateDTO>()
                .ForMember(dest => dest.CourseName,
                            opts => opts.MapFrom(src => src.CourseName))
                .ForMember(dest => dest.DepartmentID,
                            opts => opts.MapFrom(src => src.DepartmentId))
                .ReverseMap();

            CreateMap<CourseUpdateDTO, Course>()
                .ForMember(dest => dest.CourseId,
                        opts => opts.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.CourseName,
                            opts => opts.MapFrom(src => src.CourseName))
                .ForMember(dest => dest.DepartmentId,
                            opts => opts.MapFrom(src => src.DepartmentID));

            CreateMap<Course, CourseUpdateDTO>()
                .ForMember(dest => dest.CourseName,
                            opts => opts.MapFrom(src => src.CourseName))
                .ForMember(dest => dest.DepartmentID,
                            opts => opts.MapFrom(src => src.DepartmentId))
                .ReverseMap();

            CreateMap<JsonPatchDocument<CourseUpdateDTO>, JsonPatchDocument<Course>>();
            CreateMap<Operation<CourseUpdateDTO>, Operation<Course>>();
        }
    }
}