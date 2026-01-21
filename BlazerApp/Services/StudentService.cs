using System.Net;
using AutoMapper;
using BlazerApp.Models.Dtos;
using BlazerApp.Models.Entities;
using BlazerApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Somon_TJ_Nedvisimost.Data;
using WebAPIWithJWTAndIdentity.Response;

namespace BlazerApp.Services;

public class StudentService(ApplicationDbContext context, IMapper mapper) : IStudentService
{
    public async Task<Response<List<StudentDto>>> GetStudentsAsync()
    {
        /*try
        {*/

        var students = await context.Students.ToListAsync();
        var result = mapper.Map<List<StudentDto>>(students);
        var response = new Response<List<StudentDto>>
        {
            StatusCode = (int)HttpStatusCode.OK,
            Message = "Students retrieved successfully!",         
            Data = result
        };
        
        return response;
        /*}*/
        /*catch (Exception ex)
        {
            return new Response<List<TodoItemDto>>(HttpStatusCode.BadRequest, $"Error: {ex.Message}");
        }*/
    }

    public async Task<Response<StudentDto>> AddStudentAsync(AddStudentDto studentDto)
    {
        
        /*try
       {*/
        var ad = mapper.Map<Student>(studentDto);
        context.Students.Add(ad);
        await context.SaveChangesAsync();
        var result = mapper.Map<StudentDto>(ad);
        return new Response<StudentDto>(HttpStatusCode.Created, "Student created successfully!", result);
        /*}*/
        /*catch (Exception ex)
        {
            return new Response<TodoItemDto>(HttpStatusCode.BadRequest, $"Error: {ex.Message}");
        }*/
    }

    public async Task<Response<StudentDto>> UpdateStudentAsync(StudentDto studentDto)
    { 
        /*try
      {*/
        var check = await context.Students.FindAsync(studentDto.Id);
        if (check == null)
            return new Response<StudentDto>(HttpStatusCode.NotFound, "Student not found");

        check.FullName = studentDto.FullName;
        check.Email = studentDto.Email;
        check.CourseId =  studentDto.CourseId;
        await context.SaveChangesAsync();
        var result = mapper.Map<StudentDto>(check);
        
        return new Response<StudentDto>(HttpStatusCode.OK, "Student updated successfully!", result);
        /*}*/
        /*catch (Exception ex)
        {
            return new Response<TodoItemDto>(HttpStatusCode.BadRequest, $"Error: {ex.Message}");
        }*/
    }

    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        /*try
        {*/
        var student = await context.Students.FindAsync(id);
        if (student == null)
            return new Response<string>(HttpStatusCode.NotFound, "Student not found");
        context.Students.Remove(student);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK, "Student deleted successfully!");

        /*catch (Exception ex)
            {
                return new Response<string>(HttpStatusCode.BadRequest, $"Error: {ex.Message}");
            }*/ 
    }

    public async Task<Response<StudentDto>> GetStudentById(int id)
    {
        /*try
         {*/
        var student = await context.Students.FirstOrDefaultAsync(a => a.Id == id);
        if (student == null)
            return new Response<StudentDto>(HttpStatusCode.NotFound, "Student not found");
        var result = mapper.Map<StudentDto>(student);
        var response = new Response<StudentDto>(HttpStatusCode.OK, "Student retrieved successfully!", result);
        return response;
        
        /*catch (Exception ex)
        {
            return new Response<TodoItemDto>(HttpStatusCode.BadRequest, $"Error: {ex.Message}");
        }*/
    }
}

