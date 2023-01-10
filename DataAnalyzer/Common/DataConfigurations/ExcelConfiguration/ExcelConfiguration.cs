using DataAnalyzer.Common.DataConfigurations.GroupingConfigurations;
using DataAnalyzer.Common.DataParameters;
using System.Linq;

namespace DataAnalyzer.Common.DataConfigurations.ExcelConfiguration
{
    internal class ExcelConfiguration : GroupingDataConfiguration<ApplicationConfigurations.DataConfigurations.GroupingDataConfiguration>
    {
        private int groupingLevels = 3;

        // Workbook, Worksheet, Clusters
        public override int GroupingLevels
        {
            get => this.groupingLevels;
            protected set => this.groupingLevels = value;
        }

        protected override void InternalInit(
            IDataParameterCollection parameters,
            ApplicationConfigurations.DataConfigurations.GroupingDataConfiguration configuration)
        {
            for (int i = 0; i < configuration.GroupingConfiguration.Count; i++)
            {
                this.AddGroupingRule(i, parameters.GetStatAccessor(configuration.GroupingConfiguration.ElementAt(i).SelectedParameter));
            }
        }
    }
}
