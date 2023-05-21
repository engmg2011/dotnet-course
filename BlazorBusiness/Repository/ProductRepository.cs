using AutoMapper;
using BlazorBusiness.Repository.IRepository;
using BlazorDataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using ProjectModels;

namespace BlazorBusiness.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<ProductDTO> Create(ProductDTO objDTO)
    {
        var obj = _mapper.Map<ProductDTO, Product>(objDTO);
        var addedObj = _db.Products.Add(obj);
        await _db.SaveChangesAsync();
        return _mapper.Map<Product, ProductDTO>(addedObj.Entity);
    }
    
    public async Task<ProductDTO> Update(ProductDTO objDTO)
    {
        var objFromDb = _db.Products.FirstOrDefault((c)=>c.Id == objDTO.Id);
        if (objFromDb != null)
        {
            var objProduct = _mapper.Map<ProductDTO, Product>(objDTO);
            objFromDb.Name= objProduct.Name;
            objFromDb.Description= objProduct.Description;
            objFromDb.ImageUrl= objProduct.ImageUrl;
            objFromDb.CategoryId= objProduct.CategoryId;
            objFromDb.Color= objProduct.Color;
            objFromDb.ShopFavorites= objProduct.ShopFavorites;
            objFromDb.CustomerFavorites= objProduct.CustomerFavorites;
            _db.Products.Update(objFromDb);
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(objFromDb);
        }
        return objDTO;
    }
    
    public async Task<int> Delete(int id)
    {
        var category = await _db.Products.FirstOrDefaultAsync(e => e.Id == id);
        if (category is null)
        {
            return 0;
        }
        _db.Products.Remove(category);
        await _db.SaveChangesAsync();
        return category.Id;
    }

    public async Task<ProductDTO> Get(int id)
    {
        var obj = await _db.Products.FirstOrDefaultAsync((c)=>c.Id == id);
        if (obj != null)
        {
            return _mapper.Map<Product, ProductDTO>(obj);
        }
        return new ProductDTO();
    }
    
    public IEnumerable<ProductDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.Products);
    }
}