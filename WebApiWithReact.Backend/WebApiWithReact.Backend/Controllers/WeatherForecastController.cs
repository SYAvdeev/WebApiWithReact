using WebApiWithReact.Backend.Model;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWithReact.Backend.Controllers;

[ApiController]
[Route("api/weatherforecast")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = RandomNumberGenerator.GetInt32(-20, 55),
            Summary = Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)],
        })
        .ToArray();

        return forecast;
    }
}