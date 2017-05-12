using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Snowwhite.DwarfLibrary.NewsDwarf
{
    public class VisibleWhenZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var input = value as List<NewsDwarfModel> ?? null;
            if (input == null || input.Count == 0)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object v, Type t, object p, string l) => null;
    }
}
