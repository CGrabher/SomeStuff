using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SunInfo.Converters;

public class BooleanToVisibilityInverseConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {

        //vm => v
        if (value is not bool b)
        {
            throw new NotSupportedException("This converter does only support bool");
        }

        var result = b
            ? Visibility.Collapsed
            : Visibility.Visible;
        return result;


    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
