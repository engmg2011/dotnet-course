using BlazerWebAssembly.Service.IService;
using Newtonsoft.Json;
using ProjectModels;

namespace BlazerWebAssembly.Service;

public class ProductService: IProductService
{
    private HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ProductDTO> Get(int id)
    {
        var response = await _httpClient.GetAsync($"/product/{id}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductDTO>(content);
        }

        return new ProductDTO();
    }

    public async Task<IEnumerable<ProductDTO>?> GetAll()
    {
        var response = await _httpClient.GetAsync("product/");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(content);
        }

        return new List<ProductDTO>();
    }
}