using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // sources
    public class NewsSource
    {
        public string Status { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string Category { get; set; }
        public Logos URLToLogos { get; set; }
        public string[] SortBysAvailable { get; set; }
    }

    public class Logos
    {
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
    }
}
