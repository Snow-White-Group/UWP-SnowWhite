using Domain.Services;
using Domain.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using System;
using Newtonsoft.Json;

namespace ServicesGateways
{
    public class NewsService : INewsService
    {
        // api key
        private static readonly string API_KEY = "de79b1bf710e4d319ce44f6ef3de9df9";

        // instantiate the service for making requests and get responses
        private static readonly WebService service = new WebService();

        // db context for the local db
        private static readonly ServicesDbContext db = new ServicesDbContext();

        // sources => target news sources
        // returns news from the target sources
        public async Task<List<News>> GetNews(NewsSource sources)
        {
            List<News> news = new List<News>();
            List<News> badGuys = new List<News>(); // TODO @ mario -- remove list after debugging

            // delete all existing rows
            //db.News.RemoveRange(db.News);

            // get newest news from each source
            foreach (Source newsSource in sources.Sources)
            {
                // request for news
                string newsResponse = await service.MakeRequest("https://newsapi.org/v1/articles?source=" + newsSource.ID + "&sortBy=latest&apiKey=" + API_KEY);

                // parse json to news object and add to list if no error occured
                News targetnews = JsonConvert.DeserializeObject<News>(newsResponse);
                if (targetnews.Status.Equals("error"))
                {
                    badGuys.Add(targetnews);
                    continue;
                };
                targetnews.LastUpdate = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                
                news.Add(targetnews);
                //db.News.Add(targetnews);
            }

            //db.SaveChanges();

            return news.OrderBy(x => x.Source).ToList();
        }

        // get all possible sources
        public async Task<NewsSource> GetSources(string language="de")
        {
            // request
            string sourcesResponse = await service.MakeRequest("https://newsapi.org/v1/sources?language=" + language + "&apiKey=" + API_KEY);

            // parse json to source object and add to list
            NewsSource sources = JsonConvert.DeserializeObject<NewsSource>(sourcesResponse);
            sources.LastUpdate = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);

            return sources;
        }
    }
}
