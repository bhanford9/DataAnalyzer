using DataAnalyzer.DataImport.DataObjects.ClassStats;

namespace DataAnalyzer.Common.DataParameters.ClassCreationParameters;

internal class ClassCreationParameters : StatAccessorCollection<IClassStats>
{
    internal override void AddStatAccessor()
    {
        this.statAccessors.Add(new StatAccessor<IClassStats>(x => x.Name, x => true) { Name = nameof(ClassStats.Name) });
        this.statAccessors.Add(new StatAccessor<IClassStats>(x => x.Properties, x => true) { Name = nameof(ClassStats.Name) });
    }
}
