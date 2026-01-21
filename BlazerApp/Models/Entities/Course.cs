namespace BlazerApp.Models.Entities;

public class Course : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public LevelEnum Level { get; set; }
    public int DurationInHours { get; set; }
}