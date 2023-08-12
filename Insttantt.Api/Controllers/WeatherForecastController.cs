using Insttantt.Application.Bussines.Weather.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : CustomBaseController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetWeatherQuery());
            return HandleResult(result.Result, result.ErrorProvider);
        }
    }
}