using System.Threading.Tasks;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeather(string city);
    }
}