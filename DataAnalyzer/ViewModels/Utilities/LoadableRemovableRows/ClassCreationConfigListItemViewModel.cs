using DataAnalyzer.Models.ExecutionModels.ClassCreationModels;
using System;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;

internal class ClassCreationConfigListItemViewModel : LoadableRemovableRowViewModel, IClassCreationConfigListItemViewModel
{
    private readonly IClassCreationConfigurationModel classCreationConfigModel;

    public ClassCreationConfigListItemViewModel(IClassCreationConfigurationModel classCreationConfigModel)
    {
        this.classCreationConfigModel = classCreationConfigModel;
    }

    protected override void DoLoad() => this.classCreationConfigModel.LoadConfigByName(this.Value);

    protected override void InternalDoRemove() =>
        // TODO --> prompt user with confirmation
        throw new NotImplementedException();
}
