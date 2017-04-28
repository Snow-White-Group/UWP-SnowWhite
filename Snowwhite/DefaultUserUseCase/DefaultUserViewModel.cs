using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Domain.DefaultUserUseCase;
using Domain.Entities;
using DwarfLibrary.NewsDwarf;
using DwarfLibrary.WeatherDwarf;
using PropertyChanged;
using static Windows.ApplicationModel.Core.CoreApplication;

namespace Snowwhite.DefaultUserUseCase
{
    [ImplementPropertyChanged]
    public class DefaultUserViewModel : IDefaultUserPresenter
    {
        #region public
        public WeatherDwarfModel WeatherDwarfModel { get; set; }
        public List<NewsDwarfModel> NewsDwarf { get; set; }
        public int ShownNews { get; set; }
        public string MirrorName { get; set; }
        #endregion

        #region constructur
        public DefaultUserViewModel()
        {
            this.ShownNews = 3;
        }
        #endregion

        public void OnPresent(DwarfData dwarfData)
        {
            var news = dwarfData.News
                .Select(a => a.Articles.Select(b => new Tuple<Article, string>(b, a.Source)))
                .SelectMany(a => a)
                .Select(a => new NewsDwarfModel(a.Item1.Title, a.Item1.Description, a.Item1.URLToImage, a.Item2));

            //Ensure UI Thread
            Window.Current.Dispatcher?.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    NewsDwarf = news.ToList();
                });
        }
    }
}