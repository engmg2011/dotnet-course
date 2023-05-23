using BlazorBusiness.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using ProjectModels;

namespace BlazorAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController: ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var allProducts = await _productRepository.GetAll();
        return Ok(allProducts);
    }

    private BadRequestObjectResult InvalidProduct()
    {
        return BadRequest(new ErrorModelDTO()
            {
                ErrorMessage = "Invalid Id",
                StatusCode = StatusCodes.Status400BadRequest
            });
    }
    
    [HttpGet("/api/Product/{id}")]
    public async Task<ActionResult> Get(int id)
    {
        if (id == null || id == 0)
            return InvalidProduct();
        
        ProductDTO _product = await _productRepository.Get(id);
        if (_product == null)
            return InvalidProduct();
        
        return Ok(_product);
    }

}