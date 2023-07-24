using Humanizer;
using System;
using System.Globalization;
using System.Windows.Data;

namespace SunInfo.Converters;

public class TimeSpanToReadableConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not TimeSpan ts) 
        { 
             throw new NotSupportedException("Converter only supports TimeSpan");
        }

        var result = ts.Humanize(2, collectionSeparator:" ");
        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
