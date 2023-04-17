using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;
using DataAnalyzer.Services.ExcelUtilities;

namespace DataAnalyzer.Common.Mvvm.ValueConverters
{
    internal class ExcelEntityTypeToColumnVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is IExcelEntitySpecification type &&
                (type.Equals(IExcelEntitySpecification.Worksheet) || type.Equals(IExcelEntitySpecification.DataCluster) || type.Equals(IExcelEntitySpecification.Row)) ?
                Visibility.Visible : Visibility.Collapsed;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => default;
    }
}
