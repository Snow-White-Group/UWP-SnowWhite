using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Services;

namespace Domain.Test.DefaultUserUseCase.impl
{
    internal class MockWeatherService : IWeatherService
    {
        public bool Called;
        public WeatherData LoadWeatherData()
        {
            Called = true;
            return new WeatherData(23,"Sunny", new DateTime(), new List<string>(), "Achern");
        }
    }
}