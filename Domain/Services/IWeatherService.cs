namespace Domain.Services
{
    public interface IWeatherService
    {
        Task<Weather> GetWeather(string city);
        WeatherData LoadWeatherData();

    }
}