using BlazerApp.Models.Dtos;
using WebAPIWithJWTAndIdentity.Response;

namespace BlazerApp.Services.Interfaces;

public interface ICourseService
{
    public  Task<Response<List<CourseDto>>> GetAllCoursesAsync();
    public  Task<Response<CourseDto>> AddCourseAsync(AddCourseDto courseDto);
    public  Task<Response<CourseDto>> UpdateCourseAsync(CourseDto courseDto);
    public  Task<Response<string>> DeleteCourseAsync(int id);
    public  Task<Response<CourseDto>> GetCourseByid(int id);
}