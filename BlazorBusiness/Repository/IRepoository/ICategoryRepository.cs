using ProjectModels;

namespace BlazorBusiness.Repository.IRepoository;

public interface ICategoryRepository
{
    public CategoryDTO Create(CategoryDTO objDTO);

    public CategoryDTO Update(CategoryDTO objDTO);

    public int Delete(int id);

    public CategoryDTO Get(int id);

    public IEnumerable<CategoryDTO> GetAll();
    
}