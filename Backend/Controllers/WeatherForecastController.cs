using Core;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("Api/vejr")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    
    private static readonly string[] Locations =
    {
        "Aarhus",
        "Odense",
        "København",
        "Aalborg",
        "Esbjerg",
        "Vejle",
        "Randers",
        "Roskilde"
    };

    [HttpGet]
    [Route("random/{n:int}")]
    public IEnumerable<WeatherForecast> Get(int n)
    {
        List<WeatherForecast> forecasts =
            new List<WeatherForecast>();

        for (int i = 1; i <= n; i++)
        {
            WeatherForecast forecast =
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(
                        DateTime.Now.AddDays(i)
                    ),

                    TemperatureC =
                        Random.Shared.Next(1, 21),

                    Summary = Summaries[
                        Random.Shared.Next(
                            Summaries.Length)
                    ],

                    Location = Locations[
                        Random.Shared.Next(
                            Locations.Length)
                    ]
                };

            forecasts.Add(forecast);
        }

        return forecasts;
    }
}