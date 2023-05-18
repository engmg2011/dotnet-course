using Microsoft.EntityFrameworkCore;

namespace BlazorDataAccess.DataAccess;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; }
    
    
}