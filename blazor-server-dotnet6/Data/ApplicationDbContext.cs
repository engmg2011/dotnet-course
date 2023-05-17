using System;
using blazor_server_dotnet6.Model;
using Microsoft.EntityFrameworkCore;


namespace blazor_server_dotnet6.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    {
        
    }
    public DbSet<Category>? Category { get; set; }

}


