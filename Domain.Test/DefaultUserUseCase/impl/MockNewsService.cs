using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;

namespace Domain.Test.DefaultUserUseCase.impl
{
    internal class MockNewsService : INewsService
    {
        public bool Called;

        public Task<List<News>> GetNews(string[] sources)
        {
            Called = true;
            return Task<List<News>>.Factory.StartNew(() => new List<News>());
        }

        public Task<List<NewsSource>> GetSources(string language = "de")
        {
            return Task<List<NewsSource>>.Factory.StartNew(() => new List<NewsSource>());
        }
    }
}