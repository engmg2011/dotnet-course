using BlazorBusiness.Repository;
using BlazorBusiness.Repository.IRepository;
using BlazorCommon;
using BlazorDataAccess.DataAccess;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorBackend.Data;
using BlazorBackend.Service;
using BlazorBackend.Service.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        // "Server=localhost;Port=3306;Database=BlazorBackend;Uid=admin;Pwd=123456;"
        // options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
        options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                serverVersion, 
                builder => builder.MigrationsAssembly("BlazorBackend"))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
);

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

// app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseAuthentication();
app.UseAuthorization();
app.Run();
