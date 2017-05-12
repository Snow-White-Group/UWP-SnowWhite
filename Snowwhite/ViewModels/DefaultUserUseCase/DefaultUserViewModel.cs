using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Domain.DefaultUserUseCase;
using Domain.Entities;
using GalaSoft.MvvmLight;
using PropertyChanged;
using Remotion.Linq.Clauses;
using Snowwhite.DwarfLibrary.NewsDwarf;
using Snowwhite.DwarfLibrary.WeatherDwarf;
using Snowwhite.Utility;

namespace Snowwhite.ViewModels.DefaultUserUseCase
{
    [ImplementPropertyChanged]
    public class DefaultUserViewModel : ViewModelBase, IDefaultUserPresenter

    {
        #region constructur
        public DefaultUserViewModel()
            {
                this.ShownNews = 3;
            }
        #endregion
       
        #region public

            public WeatherDwarfModel WeatherDwarfModel { get; set; }

            public List<NewsDwarfModel> NewsDwarf { get; set; }

            public int ShownNews { get; set; }

            public string MirrorName = "Hello";
        #endregion

        public void OnPresent(DefaultUserResponse response)
        {
            var news =
                response.News.Select(a => a.Articles.Select(b => new Tuple<Article, string>(b, a.Source)))
                    .SelectMany(a => a)
                    .Select(a => new NewsDwarfModel(a.Item1.Title, a.Item1.Description, a.Item1.URLToImage, a.Item2))
                    .Where(a => a.Headline != null && a.ImageUrl != null && a.ShortLine != null && a.Source != null)
                    .ToList()
                    .Shuffle();

            Debug.WriteLine("News: " + news.Count());

            //Ensure UI Thread
            Window.Current.Dispatcher?.RunAsync(CoreDispatcherPriority.Normal, () => { NewsDwarf = news.ToList(); });
            
        }
    }
}