using BlazorBusiness.Repository;
using BlazorBusiness.Repository.IRepository;
using BlazorDataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var  MyAllowSpecificOrigins = "_BlazorCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        // "Server=localhost;Port=3306;Database=BlazorServer;Uid=admin;Pwd=123456;"
        // options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
        options.UseMySql("Server=localhost;Port=3306;Database=BlazorServer;Uid=admin;Pwd=123456;",
                serverVersion, 
                builder => builder.MigrationsAssembly("BlazorServer"))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();