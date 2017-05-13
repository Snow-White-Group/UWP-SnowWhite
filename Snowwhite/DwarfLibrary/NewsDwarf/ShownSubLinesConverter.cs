namespace Snowwhite.DwarfLibrary.NewsDwarf
{
    using System;
    using Windows.UI.Xaml.Data;

    public class ShownSubLinesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var input = (int) value;
            if (input > 40) return 4;
            else return 5;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}