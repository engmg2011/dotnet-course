using BlazerWebAssembly.Service.IService;
using BlazerWebAssembly.ViewModels;
using BlazorCommon;
using Blazored.LocalStorage;

namespace BlazerWebAssembly.Service;

public class CartService: ICartService
{

    public int TotalCount { get; set; } = 0; 
    
    public int GetTotalCount()
    {
        return TotalCount;
    }
 
    
    private readonly ILocalStorageService _localStorage;
    public event Func<Task>  OnChange;
    
    public CartService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    async Task SetCartItems(List<ShoppingCartProduct> list)
    {
        await _localStorage.SetItemAsync(SD.ShoppingCart, list);
        await UpdateTotalCount();
        OnChange?.Invoke();
    }

    public async Task<List<ShoppingCartProduct>> GetCartItems()
    {
        var items = await _localStorage.GetItemAsync<List<ShoppingCartProduct>>(SD.ShoppingCart);
        return items ?? new List<ShoppingCartProduct>();
    }

    public async Task DecrementCart(ShoppingCartProduct product)
    {
        List<ShoppingCartProduct> products = await GetCartItems();
        List<ShoppingCartProduct> newList = new List<ShoppingCartProduct>();
        for ( int i =0; i< products.Count; i++)
        {
            bool shouldRemove = false;
            if (products[i].ProductId == product.ProductId)
            {
                if (products[i].Count > 1) products[i].Count--;
                else shouldRemove = true;
            }
            else
            {
                Console.WriteLine("Trying to remove not existed product");
            }
            if(!shouldRemove) 
                newList.Add(products[i]);
        }
        await SetCartItems(newList);
    }
    
    public async Task RemoveFromCart(ShoppingCartProduct product)
    {
        List<ShoppingCartProduct> products = await GetCartItems();
        List<ShoppingCartProduct> newList = new List<ShoppingCartProduct>();
        for ( int i =0; i< products.Count; i++)
        {
            if(products[i].ProductId != product.ProductId) 
                newList.Add(products[i]);
        }
        await SetCartItems(newList);
    }

    public async Task AddToCart(ShoppingCartProduct product)
    {
        List<ShoppingCartProduct> products = await GetCartItems();
        bool found = false;
        for ( int i =0; i< products.Count; i++)
        {
            if (products[i].ProductId == product.ProductId)
            {
                products[i].Count += product.Count;
                found = true;
            }
        }
        if(!found)
            products.Add(product);
        await SetCartItems(products);
    }

    public async Task UpdateTotalCount()
    {
        int totalCount = 0;
        List<ShoppingCartProduct> products = await GetCartItems();
        bool found = false;
        for ( int i =0; i< products.Count; i++)
            totalCount += products[i].Count;
        TotalCount = totalCount;
    }

}