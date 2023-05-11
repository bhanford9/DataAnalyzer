using System;
using System.Globalization;
using System.Windows.Data;

namespace DataAnalyzer.Common.Mvvm.ValueConverters
{
    internal abstract class BooleanConverter<T> : IValueConverter
    {
        public T TrueValue { get; set; }
        public T FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is bool v && v ? TrueValue : FalseValue;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => value is T v && v.Equals(TrueValue);
    }
}
