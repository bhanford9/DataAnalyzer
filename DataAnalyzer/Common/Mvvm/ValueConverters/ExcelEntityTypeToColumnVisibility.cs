﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.Common.Mvvm.ValueConverters
{
    internal class ExcelEntityTypeToColumnVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is ExcelEntityType type &&
                (type.Equals(ExcelEntityType.Worksheet) || type.Equals(ExcelEntityType.DataCluster) || type.Equals(ExcelEntityType.Row)) ?
                Visibility.Visible : Visibility.Collapsed;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => default;
    }
}
