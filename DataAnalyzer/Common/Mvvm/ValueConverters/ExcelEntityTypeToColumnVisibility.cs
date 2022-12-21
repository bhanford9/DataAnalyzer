using DataAnalyzer.Services;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace DataAnalyzer.Common.Mvvm.ValueConverters
{
    internal class ExcelEntityTypeToColumnVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is ExcelEntityType type && 
                (type.Equals(ExcelEntityType.Worksheet) || type.Equals(ExcelEntityType.DataCluster) || type.Equals(ExcelEntityType.Row)) ?
                Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return default;
        }
    }
}
