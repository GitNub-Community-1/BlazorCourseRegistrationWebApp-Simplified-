using BlazerApp.Models.Entities;

namespace BlazerApp.Models.Dtos;

public class CourseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public LevelEnum Level { get; set; }
    public int DurationInHours { get; set; }
}