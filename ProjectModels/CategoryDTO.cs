using System.ComponentModel.DataAnnotations;

namespace ProjectModels;

public class CategoryDTO
{
    public int Id { get; set; }
    
    [Required (ErrorMessage = "Name is required")]
    [MinLength(5, ErrorMessage = "Please enter category full name")]
    public string? Name { get; set; }
}