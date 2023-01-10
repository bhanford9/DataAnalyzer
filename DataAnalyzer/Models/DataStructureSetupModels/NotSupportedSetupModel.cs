using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using System;

namespace DataAnalyzer.Models.DataStructureSetupModels
{
    internal class NotSupportedSetupModel : DataStructureSetupModel<NotSupportedDataConfiguration>
    {
        protected override void PrepareConfigurationForSaving(DateTime saveTime, string saveUid)
        {
        }
    }
}
