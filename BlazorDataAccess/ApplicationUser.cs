using Microsoft.AspNetCore.Identity;

namespace BlazorDataAccess;

public class ApplicationUser: IdentityUser
{
    public string Name { get; set; }
    
    public string Discriminator { get; set; }
    
}