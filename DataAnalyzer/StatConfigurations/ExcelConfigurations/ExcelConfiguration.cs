using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.StatConfigurations.GroupingConfigurations;
using System.Linq;
using AppDataConfig = DataAnalyzer.ApplicationConfigurations.DataConfigurations;

namespace DataAnalyzer.StatConfigurations.ExcelConfigurations
{
    internal class ExcelConfiguration : GroupingDataConfiguration<AppDataConfig.GroupingDataConfiguration>, IExcelConfiguration
    {
        private int groupingLevels = 3;

        // Workbook, Worksheet, Clusters
        public override int GroupingLevels
        {
            get => groupingLevels;
            protected set => groupingLevels = value;
        }

        protected override void InternalInit(IStatAccessorCollection parameters, AppDataConfig.GroupingDataConfiguration configuration)
        {
            for (int i = 0; i < configuration.GroupingConfiguration.Count; i++)
            {
                AddGroupingRule(i, parameters.GetStatAccessor(configuration.GroupingConfiguration.ElementAt(i).SelectedParameter));
            }
        }
    }
}
