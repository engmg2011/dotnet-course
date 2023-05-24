using BlazerWebAssembly.ViewModels;

namespace BlazerWebAssembly.Service.IService;

public interface ICartService
{
    Task IncrementCart(ShoppingCartProduct product);

    Task DecrementCart(ShoppingCartProduct product);
    
    
}