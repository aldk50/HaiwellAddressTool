using Avalonia.Data.Converters;
using Avalonia.Utilities;
using HaiwellTools.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiwellTools.Converters
{
    public class EnumDescriptionConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ComponentType)value).GetName();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {

                return value.ToString().GetComponentType();
            }
                return ComponentType.X;
        }
    }
}
