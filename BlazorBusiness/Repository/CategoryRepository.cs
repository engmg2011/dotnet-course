using AutoMapper;
using BlazorBusiness.Repository.IRepository;
using BlazorDataAccess;
using BlazorDataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using ProjectModels;

namespace BlazorBusiness.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public CategoryRepository(IMapper mapper, ApplicationDbContext db)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<CategoryDTO> Create(CategoryDTO objDTO)
    {
        var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
        var addedObj = _db.Categories.Add(obj);
        await _db.SaveChangesAsync();
        return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
    }
    
    public async Task<CategoryDTO> Update(CategoryDTO objDTO)
    {
        var objFromDb = await _db.Categories.FirstOrDefaultAsync((c)=>c.Id == objDTO.Id);
        if (objFromDb != null)
        {
            var objCategory = _mapper.Map<CategoryDTO, Category>(objDTO);
            objFromDb.Name= objCategory.Name;
            _db.Categories.Update(objFromDb);
            _db.SaveChanges();
            return _mapper.Map<Category, CategoryDTO>(objFromDb);
        }
        return objDTO;
    }
    
    public async Task<int> Delete(int id)
    {
        
        var category = await _db.Categories.FirstOrDefaultAsync(e => e.Id == id);
        if (category is null)
        {
            return 0;
        }
        _db.Categories.Remove(category);
        await _db.SaveChangesAsync();
        return category.Id;
    }

    
    
    public async Task<CategoryDTO> Get(int id)
    {
        var obj = await _db.Categories.FirstOrDefaultAsync((c)=>c.Id == id);
        if (obj != null)
        {
            return _mapper.Map<Category, CategoryDTO>(obj);
        }
        return new CategoryDTO();
    }
    
    public async Task<IEnumerable<CategoryDTO>> GetAll()
    {
        return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
    }
}
