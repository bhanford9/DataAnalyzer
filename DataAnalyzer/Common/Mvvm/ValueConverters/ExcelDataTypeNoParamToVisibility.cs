using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels.Parameters;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;
using DataAnalyzer.Models.ExcelSetupModels.ExcelDataTypeModels;

namespace DataAnalyzer.Common.Mvvm.ValueConverters
{
    internal class ExcelDataTypeNoParamToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return string.Empty;

            ExcelDataTypeLibrary excelDataTypeLibrary = BaseSingleton<ExcelDataTypeLibrary>.Instance;
            if (excelDataTypeLibrary.NamedTypeParameters.TryGetValue(value as string, out var param))
            {
                return param.Type == ParameterType.None ? Visibility.Visible : Visibility.Hidden;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // No need to convert back
            return default;
        }
    }
}
