using DataAnalyzer.Services.Enums;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DataAnalyzer.Common.Mvvm.ValueConverters;

internal class ActionCategoryToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is ActionCategory category)
        {
            if (parameter is ActionCategory expected)
            {
                return category.Equals(expected) ? Visibility.Visible : Visibility.Hidden;
            }
        }

        return Visibility.Hidden;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        // No need to convert back
        default;
}
