namespace Snowwhite.DwarfLibrary.NewsDwarf
{
    using System;
    using Windows.UI.Xaml.Data;

    public class ShownItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var input = value as int? ?? 1;
            return System.Convert.ToDouble(input * 220);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}