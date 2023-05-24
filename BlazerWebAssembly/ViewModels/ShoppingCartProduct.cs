using ProjectModels;

namespace BlazerWebAssembly.ViewModels;

public class ShoppingCartProduct
{
    public int ProductId { get; set; }
    public ProductDTO Product { get; set; }
    public int Count { get; set; }
}