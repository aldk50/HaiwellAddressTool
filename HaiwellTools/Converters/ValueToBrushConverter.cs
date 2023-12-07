using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Utilities;
using HaiwellTools.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HaiwellTools.Converters
{
    public class ValueToBrushConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(((int)value)==int.Parse(parameter.ToString())) return new SolidColorBrush(Colors.Green);else return new SolidColorBrush(Colors.Transparent);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
