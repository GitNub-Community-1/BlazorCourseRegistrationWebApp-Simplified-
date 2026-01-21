using AutoMapper;
using BlazerApp.Models.Dtos;
using BlazerApp.Models.Entities;

namespace BlazerApp.Mappings 
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<AddCourseDto, Course>();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<AddStudentDto, Student>();
        }
    }
}