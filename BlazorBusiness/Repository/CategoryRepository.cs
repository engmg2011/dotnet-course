using AutoMapper;
using BlazorBusiness.Mapper;
using BlazorDataAccess;
using BlazorDataAccess.DataAccess;
using ProjectModels;

namespace BlazorBusiness.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    CategoryRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public CategoryDTO Create(CategoryDTO objDTO)
    {
        var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
        var addedObj = _db.Categories.Add(obj);
        _db.SaveChanges();
        return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
    }

    public CategoryDTO Update(CategoryDTO objDTO)
    {
        var objFromDb = _db.Categories.FirstOrDefault((c)=>c.Id == objDTO.Id);
        if (objFromDb != null)
        {
            _db.Categories.Update(_mapper.Map<CategoryDTO, Category>(objDTO));
            _db.SaveChanges();
            return _mapper.Map<Category, CategoryDTO>(objFromDb);
        }
        return objDTO;
    }

    public int Delete(int id)
    {
        Category category = _mapper.Map<CategoryDTO, Category>(Get(id));
        _db.Categories.Remove(category);
        _db.SaveChanges();
        return category.Id;
    }

    public CategoryDTO Get(int id)
    {
        var obj = _db.Categories.FirstOrDefault((c)=>c.Id == id);
        if (obj != null)
        {
            return _mapper.Map<Category, CategoryDTO>(obj);
        }
        return new CategoryDTO();
    }

    public IEnumerable<CategoryDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
    }
    
}