using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using System;

namespace DataAnalyzer.ViewModels.Utilities
{
  class ConfigurationFileListItemViewModel : LoadableRemovableRowViewModel
  {
    private readonly ConfigurationModel configurationCreationModel = BaseSingleton<ConfigurationModel>.Instance;

    public ConfigurationFileListItemViewModel()
    {
    }

    protected override void DoLoad()
    {
      this.configurationCreationModel.LoadConfiguration(this.Value);
    }

    protected override void DoRemove()
    {
      // TODO --> prompt user with confirmation
      throw new NotImplementedException();
    }
  }
}
