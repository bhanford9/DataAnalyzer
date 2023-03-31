using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using System;

namespace DataAnalyzer.Models.DataStructureSetupModels
{
    internal class NotSupportedSetupModel : DataStructureSetupModel<NotSupportedDataConfiguration>, INotSupportedSetupModel
    {
        public NotSupportedSetupModel(IConfigurationModel configurationModel) : base(configurationModel)
        {
        }

        protected override void PrepareConfigurationForSaving(DateTime saveTime, string saveUid)
        {
        }
    }
}
