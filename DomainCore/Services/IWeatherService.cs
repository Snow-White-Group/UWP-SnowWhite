using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecast> GetWeather(string city);
        Task<WeatherData> LoadWeatherData(string city);
    }
}