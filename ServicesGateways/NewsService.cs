using Domain.Services;
using Domain.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using System;

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
        public async Task<List<News>> GetNews(string[] sources)
        {
            List<News> news = new List<News>();
            
            // delete all existing rows
            //db.News.RemoveRange(db.News);

            // get newest news from each source
            foreach (string source in sources)
            {
                // request for news
                string newsResponse = await service.MakeRequest("https://newsapi.org/v1/articles?source=" + source + "&sortBy=latest&apiKey=" + API_KEY);

                // parse json to news object and add to list
                News targetnews = JObject.Parse(newsResponse).ToObject<News>();
                news.Add(targetnews);
                db.News.Add(targetnews);
            }

            db.SaveChanges();

            return news.OrderBy(x => x.Source).ToList();
        }

        // get all possible sources
        public async Task<List<NewsSource>> GetSources(string language="de")
        {
            List<NewsSource> sources = new List<NewsSource>();

            // request
            string jsonResponse = await service.MakeRequest("https://newsapi.org/v1/sources?language=" + language);

            // parse json to source object and add to list
            sources.AddRange(JObject.Parse(jsonResponse).ToObject<List<NewsSource>>());

            return sources.OrderBy(x => x.Name).ToList();
        }
    }
}
