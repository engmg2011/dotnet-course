using BlazerWebAssembly.ViewModels;

namespace BlazerWebAssembly.Service.IService;

public interface ICartService
{
    event Action OnChange;
    
    Task IncrementCart(ShoppingCartProduct product);

    Task DecrementCart(ShoppingCartProduct product);

    Task<int>  TotalCount();

}