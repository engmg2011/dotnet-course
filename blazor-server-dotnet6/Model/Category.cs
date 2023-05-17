using System;
using System.ComponentModel.DataAnnotations;

namespace blazor_server_dotnet6.Model;
public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public DateTime CreatedDate { get; set; }
}