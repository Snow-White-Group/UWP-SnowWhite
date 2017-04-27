using Domain.Entities;
using System;

namespace Domain.Services
{
    public interface IWeatherService
    {
        WeatherData LoadWeatherData();
    }
}