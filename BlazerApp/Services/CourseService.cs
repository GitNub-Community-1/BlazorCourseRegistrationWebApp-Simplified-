using System.Net;
using AutoMapper;
using BlazerApp.Models.Dtos;
using BlazerApp.Models.Entities;
using BlazerApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Somon_TJ_Nedvisimost.Data;
using WebAPIWithJWTAndIdentity.Response;

namespace BlazerApp.Services;

public class CourseService(ApplicationDbContext context, IMapper mapper) : ICourseService
{
    public async Task<Response<List<CourseDto>>> GetAllCoursesAsync()
    {
        /*try
        {*/

        var courses = await context.Courses.ToListAsync();
        var result = mapper.Map<List<CourseDto>>(courses);
        var response = new Response<List<CourseDto>>
        {
            StatusCode = (int)HttpStatusCode.OK,
            Message = "Course retrieved successfully!",         
            Data = result
        };
        
        return response;
        /*}*/
        /*catch (Exception ex)
        {
            return new Response<List<TodoItemDto>>(HttpStatusCode.BadRequest, $"Error: {ex.Message}");
        }*/
    }

    public async Task<Response<CourseDto>> AddCourseAsync(AddCourseDto courseDto)
    {
         
        /*try
       {*/
        var ad = mapper.Map<Course>(courseDto);
        context.Courses.Add(ad);
        await context.SaveChangesAsync();
        var result = mapper.Map<CourseDto>(ad);
        return new Response<CourseDto>(HttpStatusCode.Created, "Course created successfully!", result);
        /*}*/
        /*catch (Exception ex)
        {
            return new Response<TodoItemDto>(HttpStatusCode.BadRequest, $"Error: {ex.Message}");
        }*/
    }

    public async Task<Response<CourseDto>> UpdateCourseAsync(CourseDto courseDto)
    {
        /*try
      {*/
        var check = await context.Courses.FindAsync(courseDto.Id);
        if (check == null)
            return new Response<CourseDto>(HttpStatusCode.NotFound, "Course not found");

        check.Title = courseDto.Title;
        check.Description = courseDto.Description;
        check.Level =  courseDto.Level;
        check.DurationInHours =  courseDto.DurationInHours;
        await context.SaveChangesAsync();
        var result = mapper.Map<CourseDto>(check);
        
        return new Response<CourseDto>(HttpStatusCode.OK, "Course updated successfully!", result);
        /*}*/
        /*catch (Exception ex)
        {
            return new Response<TodoItemDto>(HttpStatusCode.BadRequest, $"Error: {ex.Message}");
        }*/
    }

    public async Task<Response<string>> DeleteCourseAsync(int id)
    {
        /*try
       {*/
        var course = await context.Courses.FindAsync(id);
        if (course == null)
            return new Response<string>(HttpStatusCode.NotFound, "Course not found");
        context.Courses.Remove(course);
        await context.SaveChangesAsync();
        return new Response<string>(HttpStatusCode.OK, "Course deleted successfully!");

        /*catch (Exception ex)
            {
                return new Response<string>(HttpStatusCode.BadRequest, $"Error: {ex.Message}");
            }*/ 
    }

    public async Task<Response<CourseDto>> GetCourseByid(int id)
    {
        /*try
         {*/
        var course = await context.Courses.FirstOrDefaultAsync(a => a.Id == id);
        if (course == null)
            return new Response<CourseDto>(HttpStatusCode.NotFound, "Course not found");
        var result = mapper.Map<CourseDto>(course);
        var response = new Response<CourseDto>(HttpStatusCode.OK, "Course retrieved successfully!", result);
        return response;
        
        /*catch (Exception ex)
        {
            return new Response<TodoItemDto>(HttpStatusCode.BadRequest, $"Error: {ex.Message}");
        }*/
    }
}