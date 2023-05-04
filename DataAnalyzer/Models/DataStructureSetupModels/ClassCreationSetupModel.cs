using DataAnalyzer.ApplicationConfigurations.DataConfigurations.ClassSetupConfigurations;
using DataAnalyzer.Services;
using System;

namespace DataAnalyzer.Models.DataStructureSetupModels
{
    internal class ClassCreationSetupModel : DataStructureSetupModel<ClassSetupConfiguration>, IClassCreationSetupModel
    {
        public ClassCreationSetupModel(
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
