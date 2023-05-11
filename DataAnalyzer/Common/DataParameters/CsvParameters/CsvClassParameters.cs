using DataAnalyzer.DataImport.DataObjects.CsvStats;

namespace DataAnalyzer.Common.DataParameters.CsvParameters;

internal class CsvClassParameters : StatAccessorCollection<ICsvNamesStats>, ICsvClassParameters
{
    internal override void AddStatAccessor() => this.statAccessors.Add(
        new StatAccessor<ICsvNamesStats>(x => x.CsvNames, x => true) { Name = nameof(CsvNamesStats.CsvNames) });
}
