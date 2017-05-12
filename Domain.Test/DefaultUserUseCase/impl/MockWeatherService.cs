using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;

namespace Domain.Test.DefaultUserUseCase.Impl
{
    internal class MockWeatherService : IWeatherService
    {
        public bool Called { get; private set; }

        public Task<WeatherData> GetWeather(string city)
        {
            this.Called = true;
            var weather = new WeatherData(1, WeatherState.Sunny, DateTime.Now, null);
          return Task<WeatherData>.Factory.StartNew(() => weather);
        }
    }
}