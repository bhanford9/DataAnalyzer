using DataAnalyzer.Common.DataConverters.ExcelConverters.AlignmentConverters;
using DataAnalyzer.Common.DataConverters.ExcelConverters.BackgroundConverters;
using DataAnalyzer.Common.DataConverters.ExcelConverters.BooleanConverters;
using DataAnalyzer.Common.DataConverters.ExcelConverters.BorderConverters;
using DataAnalyzer.Common.DataConverters.ExcelConverters.MergeAndCenterConverters;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataConverters.ExcelConverters
{
    internal class ExcelActionParamConverters
    {
        private static readonly IReadOnlyDictionary<string, IExcelActionParamConverter> converters = new Dictionary<string, IExcelActionParamConverter>()
        {
            { new AlignmentStyleConverter ().Name, new AlignmentStyleConverter () },
            { new NthRowAlignmentStyleConverter ().Name, new NthRowAlignmentStyleConverter () },
            { new BackgroundStyleConverter ().Name, new BackgroundStyleConverter () },
            { new BorderStyleConverter ().Name, new BorderStyleConverter () },
            { new NthRowBorderStyleConverter ().Name, new NthRowBorderStyleConverter () },
            { new OpenWorkbookConverter().Name, new OpenWorkbookConverter() },
            { new HeaderBorderStyleActionConverter().Name, new HeaderBorderStyleActionConverter() },
            { new HeaderMergeCenterFullConverter().Name, new HeaderMergeCenterFullConverter() },
            { new HeaderBackgroundStyleConverter().Name, new HeaderBackgroundStyleConverter () },
        };

        public static IExcelActionParamConverter GetConverter(string name) => converters[name];

        public static TExcel ToExcel<TLocal, TExcel>(TLocal toConvert)
            where TExcel : ExcelService.DataActions.ActionParameters.IActionParameters
            where TLocal : IActionParameters
            => (TExcel)converters[toConvert.Name].ToExcel(toConvert);

        public static TLocal FromExcel<TExcel, TLocal>(TExcel toConvert)
            where TExcel : ExcelService.DataActions.ActionParameters.IActionParameters
            where TLocal : IActionParameters
            => (TLocal)converters[toConvert.Name].FromExcel(toConvert);

        public static IActionParameters FromExcel(ExcelService.DataActions.ActionParameters.IActionParameters toConvert)
            => converters[toConvert.Name].FromExcel(toConvert);

        public static ExcelService.DataActions.ActionParameters.IActionParameters ToExcel(IActionParameters toConvert)
            => converters[toConvert.Name].ToExcel(toConvert);

        public static ExcelService.DataActions.ActionParameters.IActionDefinitions ToExcelDefinitions(ICollection<IActionParameters> actionsParameters)
            => new ExcelService.DataActions.ActionParameters.ActionDefinitions(
                actionsParameters.Select(x => converters[x.Name].ToExcel(x)).ToList());
    }
}
