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
    private static List<WeatherForecast> weatherForecasts;

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
            .ToList();
        }
    }

    /// <summary>
    /// 获取所有天气预报
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return weatherForecasts;
    }

    /// <summary>
    /// 获取某一个天气预报
    /// </summary>
    /// <returns></returns>
    [HttpGet(template: "{index}")]
    public WeatherForecast GetweatherForecastsByIndex(int index)
    {
        return weatherForecasts.ElementAt(index);
    }

    /// <summary>
    /// 添加一个天气预报
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public WeatherForecast PostWeatherForecastsByIndex(WeatherForecast weatherForecast)
    {
        weatherForecasts.Add(weatherForecast);
        return weatherForecast;
    }


    [HttpPut(template: "{index}")]
    public WeatherForecast PutWeatherForecastsByIndex(int index, WeatherForecast weatherForecast)
    {
        weatherForecasts[index] = weatherForecast;
        return weatherForecasts.ElementAt(index);
    }


    [HttpPatch]
    public WeatherForecast PatchWeatherForecastsByIndex(int index)
    {
        return weatherForecasts.ElementAt(index);
    }

    /// <summary>
    /// 删除某个天气预报
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    [HttpDelete]
    public WeatherForecast DeleteWeatherForecastsByIndex(int index)
    {
        return weatherForecasts.ElementAt(index);
    }

    [HttpOptions]
    public WeatherForecast OptionsWeatherForecastsByIndex(int index)
    {
        return weatherForecasts.ElementAt(index);
    }

    [HttpHead]
    public void HeadWeatherForecastsByIndex(int index)
    {
        return ;
    }
}

