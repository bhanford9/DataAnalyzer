using Autofac;
using DataAnalyzer.DataImport.DataConverters;
using DataAnalyzer.DataImport.DataConverters.CsvConverters;
using DataAnalyzer.DataImport.DataConverters.ExcelConverters;
using DataAnalyzer.DataImport.DataConverters.ExcelConverters.AlignmentConverters;
using DataAnalyzer.DataImport.DataConverters.ExcelConverters.BackgroundConverters;
using DataAnalyzer.DataImport.DataConverters.ExcelConverters.BooleanConverters;
using DataAnalyzer.DataImport.DataConverters.ExcelConverters.BorderConverters;
using DataAnalyzer.DataImport.DataConverters.ExcelConverters.MergeAndCenterConverters;
using DataAnalyzer.DataImport.DataConverters.TimeStatConverters;
using DataAnalyzer.DataImport.DataConverters.TimeStatConverters.QueryableTimeStatConverters;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.DataImport.DataObjects.CsvStats;
using DataAnalyzer.DataImport.DataObjects.TimeStats;
using DataAnalyzer.DataImport.DataObjects.TimeStats.QueryableTimeStats;
using DependencyInjectionUtilities;
using System;

namespace DataAnalyzer.DataImport
{
    internal class DataImportContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            // DataImport.DataConverters.CsvConverters
            builder.RegisterTypeAncestors<IDataConverter, ICsvToNameListConverter, CsvToNameListConverter>();
            builder.RegisterTypeAncestors<IDataConverter, ICsvToTestConverter, CsvToTestConverter>();

            // DataImport.DataConverters.ExcelConverters.AlignmentConverters
            builder.RegisterTypeAncestors<IExcelActionParamConverter, IAlignmentStyleConverter, AlignmentStyleConverter>();
            builder.RegisterTypeAncestors<IExcelActionParamConverter, INthRowAlignmentStyleConverter, NthRowAlignmentStyleConverter>();
            
            // DataImport.DataConverters.ExcelConverters.BackgroundConverters
            builder.RegisterTypeAncestors<IExcelActionParamConverter, IBackgroundStyleConverter, BackgroundStyleConverter>();
            builder.RegisterTypeAncestors<IExcelActionParamConverter, IHeaderBackgroundStyleConverter, HeaderBackgroundStyleConverter>();

            // DataImport.DataConverters.ExcelConverters.BooleanConverters
            builder.RegisterTypeAncestors<IExcelActionParamConverter, IOpenWorkbookConverter, OpenWorkbookConverter>();
            
            // DataImport.DataConverters.ExcelConverters.BorderConverters
            builder.RegisterTypeAncestors<IExcelActionParamConverter, IBorderStyleConverter, BorderStyleConverter>();
            
            // DataImport.DataConverters.ExcelConverters.MergeAndCenterConverters
            builder.RegisterTypeAncestors<IExcelActionParamConverter, IHeaderMergeCenterFullConverter, HeaderMergeCenterFullConverter>();

            // DataImport.DataConverters.TimeStatConverters.QueryableTimeStatConverters
            builder.RegisterTypeAncestors<IDataConverter, ITimeStatsConverter, IQueryableTimeStatsConverter, QueryableTimeStatsConverter>();

            // DataImport.DataConverters
            builder.RegisterType<IDataConverterExecutive, DataConverterExecutive>();
            builder.RegisterType<IDataConverterLibrary,  DataConverterLibrary>();

            // DataImport.DataObjects.CsvStats
            builder.RegisterTypeAncestors<IComparable, IComparableList, ComparableList>();
            builder.RegisterTypeAncestors<IStats, ICsvNamesStats, CsvNamesStats>();
            builder.RegisterTypeAncestors<IStats, ICsvTestStats, CsvTestStats>();

            // DataImport.DataObjects.TimeStats.QueryableTimeStats
            builder.RegisterTypeAncestors<IStats, ITimeStats, IQueryableTimeStats, QueryableTimeStats>();

            // DataImport.DataObjects
            builder.RegisterTypeAncestors<IStats, IHeirarchalStats, HeirarchalStats>();
        }
    }
}
