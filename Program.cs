using Microsoft.EntityFrameworkCore;
using ProductCategoryApi.Models;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ensure your connection string is set up in appsettings.json

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Add controllers
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Display detailed errors in development
    app.UseSwagger(); // Enable Swagger in development
    app.UseSwaggerUI(); // Enable Swagger UI
}
else
{
    app.UseExceptionHandler("/Home/Error"); // For production error handling
    app.UseHsts(); // Add HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseRouting(); // Enable routing

app.UseAuthorization(); // Enable authorization

app.MapControllers(); // Map attribute-based routes

app.Run(); // Start the application
