using DataAnalyzer.Services.Enums;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

internal class EmptyParameters : ActionParameters, IEmptyParameters
{
    public override ActionCategory ActionCategory => ActionCategory.Unknown;

    public override string ToString() => Environment.NewLine;

    public override IActionParameters Clone() =>
        new EmptyParameters
        {
            ExcelEntityType = this.ExcelEntityType,
            Name = this.Name
        };
}
