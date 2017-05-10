using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;

namespace Domain.Test.DefaultUserUseCase.impl
{
    internal class MockWeatherService : IWeatherService
    {
        public bool Called { get; private set; }

        public Task<WeatherForecast> GetWeather(string city)
        {
            this.Called = true;
            var weather = new WeatherForecast();
            weather.city = new City();
            weather.city.name = "Karlsruhe";
            return Task<WeatherForecast>.Factory.StartNew(() => weather);
        }
    }
}