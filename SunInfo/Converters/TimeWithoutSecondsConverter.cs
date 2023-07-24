using System;
using System.Globalization;
using System.Windows.Data;

namespace SunInfo.Converters
{
    public class TimeWithoutSecondsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not TimeSpan timeSpan)
                return string.Empty;

            var result = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}";
            return result;        
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
