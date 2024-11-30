using ASP.NET_Ecommerce_Web_API.Controllers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
  options.InvalidModelStateResponseFactory = context =>
  {
    var errors = context.ModelState.Where(e => e.Value != null && e.Value.Errors.Count > 0).SelectMany(e => e.Value?.Errors != null ? e.Value.Errors.Select(x => x.ErrorMessage) : new List<string>()).ToList();

    return new BadRequestObjectResult(APIResponse<object>.ErrorResponse(errors, 400, "Validation failed"));
  };
});

var app = builder.Build();

app.UseHttpsRedirection();

// Homepage
app.MapGet("/", () => "API is working fine!");

// Map controller
app.MapControllers();

app.Run();