namespace BlazerApp.Models.Entities;

public class Student : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public int CourseId { get; set; }
    public Course Course { get; set; }
}