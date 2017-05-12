using System.Collections.Generic;

namespace Domain.Entities
{
    public class DwarfData
    {
        public WeatherData Weather;
        public List<News> News;

        public DwarfData(WeatherData weather, List<News> news)
        {
            this.Weather = weather;
            this.News = news;
        }
    }
}