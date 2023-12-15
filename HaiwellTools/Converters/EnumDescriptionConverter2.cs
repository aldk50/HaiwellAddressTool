using Avalonia.Data.Converters;
using HaiwellTools.Models;
using System;
using System.Globalization;


namespace HaiwellTools.Converters
{
    public class EnumDescriptionConverter2 : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((SizeType)value).GetName();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {

                return value.ToString().GetComponentSizeType();
            }
                return SizeType.Non;
        }
    }
}
