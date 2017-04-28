using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;

namespace Domain.Test.DefaultUserUseCase.impl
{
    internal class MockWeatherService : IWeatherService
    {
        public bool Called;
        public Task<Weather> GetWeather(string city)
        {
            throw new NotImplementedException();
        }

        public WeatherData LoadWeatherData()
        {
            Called = true;
            return new WeatherData(23,"Sunny", new DateTime(), new List<string>(), "Achern");
        }
    }
}