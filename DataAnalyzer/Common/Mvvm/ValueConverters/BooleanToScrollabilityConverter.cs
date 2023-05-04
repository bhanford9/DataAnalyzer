using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataAnalyzer.Common.Mvvm.ValueConverters
{
    internal class BooleanToScrollabilityConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture) =>
            value is bool v && v ? ScrollBarVisibility.Auto : ScrollBarVisibility.Hidden;

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture) => default;
    }
}
