using System.ComponentModel.DataAnnotations;

namespace ProjectModels;

public class ProductDTO
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public bool ShopFavorites { get; set; }
    [Required]
    public bool CustomerFavorites { get; set; }
    [Required]
    public string Color { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required, Range(1, int.MaxValue, ErrorMessage = "Please select a categoty")]
    public int CategoryId { get; set; }
    public CategoryDTO Category { get; set; }
}