using BlazerWebAssembly.ViewModels;

namespace BlazerWebAssembly.Service.IService;

public interface ICartService
{
    event Func<Task> OnChange;
    
    Task AddToCart(ShoppingCartProduct product);

    Task RemoveFromCart(ShoppingCartProduct product);
    
    Task DecrementCart(ShoppingCartProduct product);

    public int TotalCount  { get; set; } 
    
    Task UpdateTotalCount();

    Task<List<ShoppingCartProduct>> GetCartItems();
}