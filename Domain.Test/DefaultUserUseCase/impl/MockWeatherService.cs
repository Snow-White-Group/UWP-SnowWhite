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
            throw new NotImplementedException();
        }

        public WeatherData LoadWeatherData()
        {
            this.Called = true;
            return new WeatherData(23, WeatherState.Sunny, new DateTime(), null, "Achern");
        }

        public Task<WeatherData> LoadWeatherData(string city)
        {
            throw new NotImplementedException();
        }
    }
}