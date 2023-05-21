using BlazorBusiness.Repository;
using BlazorBusiness.Repository.IRepository;
using BlazorDataAccess.DataAccess;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        // "Server=localhost;Port=3306;Database=BlazorServer;Uid=admin;Pwd=123456;"
        options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
        // var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
        // options.UseMySql("Server=localhost;Port=3306;Database=BlazorServer;Uid=admin;Pwd=123456;",serverVersion)
        //     .LogTo(Console.WriteLine, LogLevel.Information)
        //     .EnableSensitiveDataLogging()
        //     .EnableDetailedErrors();
    }
);
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();