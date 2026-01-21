using System.ComponentModel.DataAnnotations;

namespace BlazerApp.Models.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}