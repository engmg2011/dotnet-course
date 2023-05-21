using BlazorDataAccess;
using BlazorDataAccess.DataAccess;
using ProjectModels;

namespace BlazorBusiness.Mapper;

using AutoMapper;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}