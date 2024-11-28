using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the controller
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

// Homepage
app.MapGet("/", () => "API is working fine!");

// Map controller
app.MapControllers();

app.Run();