using System;

namespace DataAnalyzer.ViewModels.Utilities
{
  public class ActionListItemViewModel : LoadableRemovableRowViewModel
  {
    protected override void DoLoad()
    {
      // could be built in or custom
    }

    protected override void InternalDoRemove()
    {
      // TODO --> Prompt user with "Are you sure?"
      throw new NotImplementedException();
    }
  }
}
