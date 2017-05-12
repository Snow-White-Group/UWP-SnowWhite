using PropertyChanged;

namespace Snowwhite.DwarfLibrary.NewsDwarf
{
    [ImplementPropertyChanged]
    public class NewsDwarfModel
    {
        public NewsDwarfModel(
          string headline,
          string shortLine,
          string imageUrl,
          string source)
        {
            this.Headline = headline;
            this.ShortLine = shortLine;
            this.ImageUrl = imageUrl;
            this.Source = source;
        }

        public string Headline { get; set; }

        public string ShortLine { get; set; }

        public string ImageUrl { get; set; }

        public string Source { get; set; }
    }
}