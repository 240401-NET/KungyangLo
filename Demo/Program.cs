using Demo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Select all tools
DemoDbContext context = new DemoDbContext();

// IEnumerable<Tool> tools = context.Tools.ToList();

// foreach(Tool tool in tools)
// {
//     Console.WriteLine(tool);
// }

//stored procedure getBudgetTool
// var tools_ = context.Tools
//     .FromSql($"EXECUTE dbo.getBudgetTool")
//     .ToList();

// foreach(Tool tool in tools_)
// {
//     Console.WriteLine(tool);
// }

//stored procedure getToolsUnderPrice
// var tools_2 = context.Tools
//     .FromSql($"EXECUTE dbo.getToolsUnderPrice {300}")
//     .ToList();

// foreach(Tool tool in tools_2)
// {
//     Console.WriteLine(tool);
// }

//stored procedure getToolsBetweenPrice with multiple parameters
var highPrice = new SqlParameter("highPrice", 80);
var lowPrice = new SqlParameter("lowPrice", 50);

var tools_3 = context.Tools
    .FromSql($"EXECUTE dbo.getToolsBetweenPrice @lowPrice = {lowPrice}, @highPrice = {highPrice}")
    .ToList();

foreach(Tool tool in tools_3)
{
    Console.WriteLine(tool);
}


































// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// // var summaries = new[]
// // {
// //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// // };

// // app.MapGet("/weatherforecast", () =>
// // {
// //     var forecast =  Enumerable.Range(1, 5).Select(index =>
// //         new WeatherForecast
// //         (
// //             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
// //             Random.Shared.Next(-20, 55),
// //             summaries[Random.Shared.Next(summaries.Length)]
// //         ))
// //         .ToArray();
// //     return forecast;
// // })
// // .WithName("GetWeatherForecast")
// // .WithOpenApi();

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
