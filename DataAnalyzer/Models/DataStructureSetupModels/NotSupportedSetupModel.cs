using DataAnalyzer.ApplicationConfigurations.DataConfigurations;
using DataAnalyzer.Services;
using System;

namespace DataAnalyzer.Models.DataStructureSetupModels
{
    internal class NotSupportedSetupModel : DataStructureSetupModel<NotSupportedDataConfiguration>, INotSupportedSetupModel
    {
        public NotSupportedSetupModel(
            ISerializationService serializationService, 
            IConfigurationModel configurationModel)
            : base(serializationService, configurationModel)
        {
        }

        protected override void PrepareConfigurationForSaving(DateTime saveTime, string saveUid)
        {
        }
    }
}
