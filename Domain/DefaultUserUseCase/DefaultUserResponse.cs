using System.Collections.Generic;
using Domain.Entities;

namespace Domain.DefaultUserUseCase
{
    public class DefaultUserResponse
    {
        public WeatherData Weather { get; }
        public List<News> News { get; }

        public DefaultUserResponse(WeatherData weather, List<News> news)
        {
            Weather = weather;
            News = news;
        }
    }
}