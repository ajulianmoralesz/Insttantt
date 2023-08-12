using Insttant.DataAccess.Repositories;
using Insttantt.Application.Handlers.ResponseHandlers;
using Insttantt.Domain.Entities;
using Insttantt.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insttantt.Application.Bussines.Weather.Queries
{
    public class GetWeatherQuery : IRequest<Response<List<WeatherForecast>>>
    {

    }
    public class GetWeatherQueryHandler : IRequestHandler<GetWeatherQuery, Response<List<WeatherForecast>>>
    {

        public async Task<Response<List<WeatherForecast>>> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
        {

            var response = new Response<List<WeatherForecast>>();
            try
            {
                var Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
                response.Result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();

            }
            catch (Exception ex)
            {
                response.ErrorProvider.AddError(ex.Source, ex.GetBaseException().Message);
            }
            return response;
        }
    }
}
