using DataAnalyzer.Services.ExcelUtilities;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DataAnalyzer.Common.Mvvm.ValueConverters;

internal class ExcelEntityTypeToRowVisibility : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is IExcelEntitySpecification type && (type.Equals(IExcelEntitySpecification.Worksheet) || type.Equals(IExcelEntitySpecification.DataCluster)) ?
            Visibility.Visible : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => default;
}
