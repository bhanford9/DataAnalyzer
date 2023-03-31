using DataAnalyzer.ViewModels.Utilities.ExecutiveCommissioners;
using System;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows
{
    class ConfigurationFileListItemViewModel : LoadableRemovableRowViewModel, IConfigurationFileListItemViewModel
    {
        private readonly IStructureExecutiveCommissioner executiveCommissioner;

        public ConfigurationFileListItemViewModel(IStructureExecutiveCommissioner executiveCommissioner)
        {
            this.executiveCommissioner = executiveCommissioner;
        }

        protected override void DoLoad() => this.executiveCommissioner.LoadConfiguration(this.Value);

        protected override void InternalDoRemove() =>
            // TODO --> prompt user with confirmation
            throw new NotImplementedException();
    }
}
