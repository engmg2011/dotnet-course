using ProjectModels;

namespace BlazerWebAssembly.Service.IService;

public interface IProductService
{
    Task<ProductDTO> Get(int id);

    Task<IEnumerable<ProductDTO>> GetAll();
}