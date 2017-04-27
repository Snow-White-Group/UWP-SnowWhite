using System.Collections.Generic;
using Domain.Entities;

namespace Domain.DefaultUserUseCase
{
    public class DefaultUserResponse
    {
        public MirrorUser User { get; }
        public WeatherData Weather { get; }
        public List<News> News { get; }

        public DefaultUserResponse(MirrorUser user, WeatherData weather, List<News> news)
        {
            User = user;
            Weather = weather;
            News = news;
        }
    }
}