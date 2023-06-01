using BlazorBusiness.Repository;
using BlazorBusiness.Repository.IRepository;
using BlazorDataAccess.DataAccess;
using BlazorBackend.Data;
using BlazorBackend.Service;
using BlazorBackend.Service.IService;
using BlazorDataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
        options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                serverVersion, 
                builder => builder.MigrationsAssembly("BlazorBackend"))
            .LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging().EnableDetailedErrors();
    }
);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddDefaultTokenProviders().AddDefaultUI() .AddEntityFrameworkStores<ApplicationDbContext>();;
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseAuthentication();
app.UseAuthorization();
app.Run();
