using AutoToll.Domain.Interfaces;
using AutoToll.Domain.Rules;
using AutoToll.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// ==================================
// DEPENDENCY INJECTION - CORE DOMAIN
// ==================================
// 1. Register business rules (toll rules)
builder.Services.AddSingleton<ITollRule, StandardCarRule>();
builder.Services.AddSingleton<ITollRule, TruckRule>();
builder.Services.AddSingleton<ITollRule, MotorcycleRule>();
// builder.Services.AddSingleton<ITollRule, WeekendDiscountRule>();
// 2. Register the TollCalculator service, which depends on the registered ITollRule implementations
// Uses AddScoped to create a new instance of TollCalculator for each HTTP request, ensuring that it gets the latest set of rules if they were to be modified at runtime (e.g., via an admin interface).
// Avoids Captive Dependency and potential issues with shared state in a singleton service, while still allowing for efficient reuse of the TollCalculator within the scope of a single request.
// Ensures DBContext (if used) is properly scoped and disposed of with the TollCalculator, preventing memory leaks and ensuring thread safety.
builder.Services.AddScoped<TollCalculator>();
// ==================================

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseAuthorization();
app.MapControllers();
//app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast =  Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

app.Run();

//record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
