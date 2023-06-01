using BlazorDataAccess;
using Microsoft.AspNetCore.Identity;

namespace BlazorBusiness.Repository.IRepository;

public interface IUserRepository 
{
    
    public Task<ApplicationUser> Create(ApplicationUser objDTO);

    public Task<ApplicationUser> Update(ApplicationUser objDTO);

    public Task<int> Delete(int id);

    public Task<ApplicationUser> Get(string id);
    
    public Task<ApplicationUser> GetByEmail(string id);

    public Task<IEnumerable<ApplicationUser>> GetAll();
    
}