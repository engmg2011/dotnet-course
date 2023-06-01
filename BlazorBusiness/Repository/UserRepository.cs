using BlazorBusiness.Repository.IRepository;
using BlazorDataAccess;
using BlazorDataAccess.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorBusiness.Repository;

public class UserRepository: IUserRepository
{
    private readonly ApplicationDbContext _db;
    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public Task<ApplicationUser> Create(ApplicationUser objDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ApplicationUser> Update(ApplicationUser objDTO)
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApplicationUser> Get(string id)
    {
        return  await _db.Users.FirstAsync( user => user.Id == id );
    }

    public async Task<ApplicationUser> GetByEmail(string email)
    {
        var user =  await _db.ApplicationUsers.FirstOrDefaultAsync( user => user.Email == email );
        if (user == null)
        {
            throw new Exception($"User with email {email} not found");
        }
        return user;
    }

    public Task<IEnumerable<ApplicationUser>> GetAll()
    {
        throw new NotImplementedException();
    }
}