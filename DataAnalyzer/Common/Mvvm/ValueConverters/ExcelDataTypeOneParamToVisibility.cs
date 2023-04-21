using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DataAnalyzer.Common.Mvvm.ValueConverters
{
    internal class ExcelDataTypeOneParamToVisibility : IValueConverter
    {
        private IExcelDataTypeLibrary excelDataTypeLibrary;

        public ExcelDataTypeOneParamToVisibility(IExcelDataTypeLibrary excelDataTypeLibrary) =>
            this.excelDataTypeLibrary = excelDataTypeLibrary;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return string.Empty;

            if (this.excelDataTypeLibrary.NamedTypeParameters.TryGetValue(value as string, out var param))
            {
                return param.Type == ParameterType.None ? Visibility.Collapsed : Visibility.Visible;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            // No need to convert back
            default;
    }
}
