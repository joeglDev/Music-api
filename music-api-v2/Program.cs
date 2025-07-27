using Microsoft.OpenApi.Models;
using music_api_v2.Database;
using music_api_v2.Services;

// seed database
var dbSeeder = new DatabaseSeeder();
await dbSeeder.SeedDatabase();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalHost",
        policy => policy
            .WithOrigins("http://localhost:5173")
            .WithMethods("GET", "POST", "PATCH", "DELETE")
            .AllowAnyHeader()
            .AllowCredentials());
});

// Register DatabaseService
builder.Services.AddSingleton<DatabaseService>();

// Register AlbumService
builder.Services.AddScoped<IAlbumService, AlbumService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowLocalHost");
    app.MapOpenApi();  // This adds the OpenAPI/Swagger endpoint
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
    });
}

app.MapControllers();

app.Run();