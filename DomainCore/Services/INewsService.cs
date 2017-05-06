using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface INewsService
    {
        Task<List<News>> GetNews(NewsSource sources);
        Task<NewsSource> GetSources(string language = "de");
    }
}
