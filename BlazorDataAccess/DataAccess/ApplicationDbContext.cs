using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorDataAccess.DataAccess;

public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
}