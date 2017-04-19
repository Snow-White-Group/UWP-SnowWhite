using Domain.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using System;

namespace ServicesGateways
{
    public class NewsService
    {
        // api key
        private static readonly string API_KEY = "de79b1bf710e4d319ce44f6ef3de9df9";

        // http client with timeout
        private static readonly HttpClient httpClient = new HttpClient(new HttpClientHandler())
        {
            Timeout = TimeSpan.FromSeconds(5)
        };

        // sources => target news sources
        // returns news from the target sources
        public async Task<List<News>> GetNews(string[] sources)
        {
            List<News> news = new List<News>();

            // get newest news from each source
            foreach (string source in sources)
            {
                // request => return json response
                HttpResponseMessage response = await httpClient.GetAsync("https://newsapi.org/v1/articles?source=" + source + "&sortBy=latest&apiKey=" + API_KEY);

                // parse json to news object and add to list
                news.Add(JObject.Parse(await response.Content.ReadAsStringAsync()).ToObject<News>());
            }

            return news.OrderBy(x => x.Source).ToList();
        }

        // get all possible sources
        public async Task<List<NewsSource>> GetSources(string language="de")
        {
            List<NewsSource> sources = new List<NewsSource>();

            // request
            HttpResponseMessage response = await httpClient.GetAsync("https://newsapi.org/v1/sources?language=" + language);

            // add all returned sources
            sources.AddRange(JObject.Parse(await response.Content.ReadAsStringAsync()).ToObject<List<NewsSource>>());

            return sources.OrderBy(x => x.Name).ToList();
        }
    }
}
