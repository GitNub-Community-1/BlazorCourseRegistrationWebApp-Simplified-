using BlazerApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Somon_TJ_Nedvisimost.Data;


public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) 
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
}