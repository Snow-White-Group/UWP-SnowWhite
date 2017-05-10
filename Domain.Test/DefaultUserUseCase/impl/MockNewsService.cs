using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;

namespace Domain.Test.DefaultUserUseCase.impl
{
    internal class MockNewsService : INewsService
    {
        public bool Called { get; private set; }

        public Task<NewsSource> GetSources(string language = "de")
        {
            return Task<NewsSource>.Factory.StartNew(() => new NewsSource());
        }

        public Task<List<News>> GetNews(NewsSource sources)
        {
            this.Called = true;
            return Task<List<News>>.Factory.StartNew(() => new List<News>());
        }
    }
}