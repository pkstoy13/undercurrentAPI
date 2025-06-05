using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using undercurrentAPI.Models; // Namespace where ArtistDbContext and models live
using undercurrentAPI.Data;   // Namespace where DbSeeder is located
using undercurrentAPI.Mappings;


var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<ArtistDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//add controllers
builder.Services.AddControllers(); 
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Undercurrent API", Version = "v1" });
});

var app = builder.Build();

// Apply migrations + seed data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ArtistDbContext>();
    dbContext.Database.Migrate();
    DbSeeder.Seed(dbContext);
}

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Undercurrent API v1");
    });
}

app.UseHttpsRedirection();

//sets up Controllers
app.MapControllers(); 


app.Run();

