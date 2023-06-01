using BlazorBusiness.Repository.IRepository;
using BlazorDataAccess;
using BlazorDataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BlazorBusiness.Repository;

public class UserRepository: IUserRepository
{
    
    private readonly ApplicationDbContext _db;
    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<ApplicationUser> Create(ApplicationUser objDTO)
    {
        var addedObj = _db.ApplicationUsers.Add(objDTO);
        await _db.SaveChangesAsync();
        if (addedObj == null)
        {
            throw new Exception("Coudn't create user");
        }
        return addedObj.Entity;
    }

    public async Task<ApplicationUser> Update(ApplicationUser objDTO)
    {
        var user = await _db.ApplicationUsers.FirstAsync(u => u.Id == objDTO.Id);
        user.Email = objDTO.Email;
        user.Name = objDTO.Name;
        user.UserName = objDTO.UserName;
        user.EmailConfirmed = objDTO.EmailConfirmed;
        user.PhoneNumber = objDTO.PhoneNumber;
        _db.Update(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<string> Delete(string id)
    {
        var user = await _db.ApplicationUsers.FirstAsync(u => u.Id == id);
        if(user == null)
        {
            throw new Exception($"User with Id: {id} not found");
        }
        var removed = _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        return id;
    }

    public async Task<ApplicationUser> Get(string id)
    {
        var user = await _db.ApplicationUsers.FirstAsync(u => u.Id == id);
        if(user == null)
        {
            throw new Exception($"User with Id: {id} not found");
        }

        return user;
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

    public async Task<IEnumerable<ApplicationUser>> GetAll()
    {
        return _db.ApplicationUsers;
    }
}