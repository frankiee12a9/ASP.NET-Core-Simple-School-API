using AutoMapper;
using SchoolApiSrc.Models;
using SchoolApiSrc.DTOs.StudentDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace SchoolApiSrc.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentReadDTO>()
                .ForMember(dest => dest.Name,
                        opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email,
                        opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.StudentType,
                        opts => opts.MapFrom(src => src.StudentType))
                .ForMember(dest => dest.EnrolledCourses,
                        opts => opts.MapFrom(src => src.CourseEnrollments.Count))
                // .ForMember(dest => dest.DictCourses,
                // opts => opts.MapFrom(src => src.CourseEnrollments))
                .ReverseMap();

            CreateMap<Student, StudentCreateDTO>()
                .ForMember(dest => dest.Name,
                        opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email,
                        opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.StudentType,
                        opts => opts.MapFrom(src => src.StudentType))
                .ForMember(dest => dest.DepartmentID,
                        opts => opts.MapFrom(src => src.DepartmentId))
                .ReverseMap();

            CreateMap<StudentUpdateDTO, Student>()
                .ForMember(dest => dest.Name,
                        opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email,
                        opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.StudentType,
                        opts => opts.MapFrom(src => src.StudentType))
                .ForMember(dest => dest.DepartmentId,
                        opts => opts.MapFrom(src => src.DepartmentID))
                .ReverseMap();

            CreateMap<JsonPatchDocument<StudentUpdateDTO>, JsonPatchDocument<Student>>();
            CreateMap<Operation<StudentUpdateDTO>, Operation<Student>>();

        }
    }
}