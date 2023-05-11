using System;
using System.Globalization;
using System.Windows.Data;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.DataTypeConfigViewModels;

namespace DataAnalyzer.Common.Mvvm.ValueConverters;

internal class ExcelDataTypeToConcreteIntParam : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is OneParameterDataTypeViewModel<int> v ?
            v :
            value;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        // No need to convert back
        default;
}
