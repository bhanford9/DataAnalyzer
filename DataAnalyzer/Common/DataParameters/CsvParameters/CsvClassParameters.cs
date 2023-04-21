using DataAnalyzer.DataImport.DataObjects.CsvStats;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.Common.DataParameters.CsvParameters
{
    internal class CsvClassParameters : DataParameterCollection<ICsvNamesStats>, ICsvClassParameters
    {
        public override StatType StatType => StatType.CsvNames;

        internal override void AddParameters() => this.parameters.Add(
            new DataParameter<ICsvNamesStats>(x => x.CsvNames, x => true) { Name = nameof(CsvNamesStats.CsvNames) });
    }
}
