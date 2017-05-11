using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeather(string city);
    }
}