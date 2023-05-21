using ProjectModels;

namespace BlazorBusiness.Repository.IRepository;

public interface IProductRepository
{
    public Task<ProductDTO> Create(ProductDTO objDTO);

    public Task<ProductDTO> Update(ProductDTO objDTO);

    public Task<int> Delete(int id);

    public Task<ProductDTO> Get(int id);

    public IEnumerable<ProductDTO> GetAll();
}