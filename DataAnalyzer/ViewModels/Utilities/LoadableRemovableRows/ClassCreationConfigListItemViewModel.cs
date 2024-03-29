﻿using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExecutionModels.ClassCreationModels;
using System;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows
{
    internal class ClassCreationConfigListItemViewModel : LoadableRemovableRowViewModel
    {
        private readonly ClassCreationConfigurationModel classCreationConfigModel =
            BaseSingleton<ClassCreationConfigurationModel>.Instance;

        protected override void DoLoad() => this.classCreationConfigModel.LoadConfigByName(this.Value);

        protected override void InternalDoRemove() =>
            // TODO --> prompt user with confirmation
            throw new NotImplementedException();
    }
}
