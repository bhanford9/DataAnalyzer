using DataAnalyzer.Common.Mvvm;
using System;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows
{
    class ConfigurationFileListItemViewModel : LoadableRemovableRowViewModel
    {
        private readonly StructureExecutiveCommissioner executiveCommissioner = BaseSingleton<StructureExecutiveCommissioner>.Instance;

        public ConfigurationFileListItemViewModel() { }

        protected override void DoLoad() => this.executiveCommissioner.LoadConfiguration(this.Value);

        protected override void InternalDoRemove() =>
            // TODO --> prompt user with confirmation
            throw new NotImplementedException();
    }
}
