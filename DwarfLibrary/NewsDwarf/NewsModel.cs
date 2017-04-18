namespace DwarfLibrary.NewsDwarf
{
    public class NewsModel
    {
        public string Headline { get; set; }
        public string ShortLine { get; set; }
        public string ImageUrl { get; set; }
        public string Source { get; set; }

        public NewsModel(string headline, string shortLine, string imageUrl, string source)
        {
            Headline = headline;
            ShortLine = shortLine;
            ImageUrl = imageUrl;
            Source = source;
        }
    }
}