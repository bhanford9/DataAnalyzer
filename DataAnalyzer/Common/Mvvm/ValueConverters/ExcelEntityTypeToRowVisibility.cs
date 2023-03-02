using DataAnalyzer.Services.Enums;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DataAnalyzer.Common.Mvvm.ValueConverters
{
    internal class ExcelEntityTypeToRowVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is ExcelEntityType type && (type.Equals(ExcelEntityType.Worksheet) || type.Equals(ExcelEntityType.DataCluster)) ?
                Visibility.Visible : Visibility.Collapsed;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => default;
    }
}
