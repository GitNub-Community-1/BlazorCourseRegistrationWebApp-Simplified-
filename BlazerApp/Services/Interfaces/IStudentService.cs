using BlazerApp.Models.Dtos;
using WebAPIWithJWTAndIdentity.Response;

namespace BlazerApp.Services.Interfaces;

public interface IStudentService
{
    public  Task<Response<List<StudentDto>>> GetStudentsAsync();
    public  Task<Response<StudentDto>> AddStudentAsync(AddStudentDto studentDto);
    public  Task<Response<StudentDto>> UpdateStudentAsync(StudentDto studentDto);
    public  Task<Response<string>> DeleteStudentAsync(int id);
    public  Task<Response<StudentDto>> GetStudentById(int id);
}