using System;
using Microsoft.AspNetCore.Mvc;
using WebApi002;

namespace WebApi002.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private static IEnumerable<WeatherForecast> weatherForecasts;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    static WeatherForecastController()
    {
        if (weatherForecasts == null)
        {
            weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return weatherForecasts;
    }

    [HttpGet(template:"index")]
    public WeatherForecast GetweatherForecastsByIndex(int index)
    {
        return weatherForecasts.ElementAt(index);
    }

    [HttpPost]
    public WeatherForecast weatherForecastsByIndex(int index)
    {
        return weatherForecasts.ElementAt(index);
    }
}

