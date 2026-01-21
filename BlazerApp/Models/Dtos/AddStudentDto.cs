namespace BlazerApp.Models.Dtos;

public class AddStudentDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    
    public int CourseId { get; set; }
}