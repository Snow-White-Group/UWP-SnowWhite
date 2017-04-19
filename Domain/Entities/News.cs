using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // news
    public class News
    {
        public string Status { get; set; }
        public string Source { get; set; }
        public string SortBy { get; set; }
        public List<Article> Articles { get; set; }
    }

    public class Article
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string URLToImage { get; set; }
        public string PublishedAt { get; set; }
    }
}
