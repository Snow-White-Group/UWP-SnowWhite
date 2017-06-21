using System.Collections.Generic;
using Domain.Entities;

namespace Domain.DefaultUserUseCase
{
    public class DefaultUserResponse
    {
        public WeatherData Weather { get; }
        public List<News> News { get; }
        public string Name { get; }

        public DefaultUserResponse(WeatherData weather, List<News> news, string name)
        {
            Weather = weather;
            News = news;
            Name = name;
        }
    }
}