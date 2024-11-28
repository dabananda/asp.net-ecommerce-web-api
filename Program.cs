using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the controller
// builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
// {
//   // disable automatic model validation response
//   options.SuppressModelStateInvalidFilter = true;
// });

builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
  options.InvalidModelStateResponseFactory = context =>
  {
    var errors = context.ModelState.Where(e => e.Value != null && e.Value.Errors.Count > 0).Select(e => new
    {
      Field = e.Key,
      Errors = e.Value != null ? e.Value.Errors.Select(x => x.ErrorMessage).ToArray() : new string[0],
    }).ToList();

    var errorString = string.Join("; ", errors.Select(e => $"{e.Field}: {string.Join(", ", e.Errors)}"));

    return new BadRequestObjectResult(new
    {
      Message = "Validation failed",
      Errors = errorString,
    });
  };
});

var app = builder.Build();

app.UseHttpsRedirection();

// Homepage
app.MapGet("/", () => "API is working fine!");

// Map controller
app.MapControllers();

app.Run();