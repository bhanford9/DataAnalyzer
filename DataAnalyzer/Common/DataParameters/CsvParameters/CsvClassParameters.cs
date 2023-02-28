using DataAnalyzer.Common.DataObjects.CsvStats;
using DataAnalyzer.Services.Enums;

namespace DataAnalyzer.Common.DataParameters.CsvParameters
{
    internal class CsvClassParameters : DataParameterCollection
    {
        public override StatType StatType => StatType.CsvNames;

        protected override void InitializeParameters()
        {
            this.parameters.Add(
                new DataParameter(
                    x => (x as CsvNamesStats).CsvNames,
                    x => x is CsvNamesStats)
                {
                    Name = nameof(CsvNamesStats.CsvNames)
                });
        }
    }
}
