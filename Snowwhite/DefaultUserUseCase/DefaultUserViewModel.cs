using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DwarfLibrary.NewsDwarf;
using DwarfLibrary.WeatherDwarf;
using PropertyChanged;

namespace Snowwhite.DefaultUserUseCase
{
    [ImplementPropertyChanged]
    public class DefaultUserViewModel
    {
        #region public
        public WeatherDwarfModel WeatherDwarfModel { get; set; }
        public NewsDwarfModel NewsDwarf { get; set; }
        public int ShownNews { get; set; }
        public string MirrorName { get; set; }
        #endregion

        #region constructur
        public DefaultUserViewModel()
        {
            this.ShownNews = 3;
        }
        #endregion

    }
}
