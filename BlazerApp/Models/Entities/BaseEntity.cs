using System.ComponentModel.DataAnnotations;
//True Structure By Abubakr
namespace BlazerApp.Models.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}