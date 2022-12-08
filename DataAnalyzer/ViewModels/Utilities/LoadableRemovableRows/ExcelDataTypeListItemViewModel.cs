using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels;
using System;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows
{
    internal class ExcelDataTypeListItemViewModel : LoadableRemovableRowViewModel
    {
        private readonly ExcelConfigurationModel excelConfigurationModel = BaseSingleton<ExcelConfigurationModel>.Instance;

        protected override void DoLoad()
        {
            this.excelConfigurationModel.LoadDataTypeConfigByName(this.Value);
        }

        protected override void InternalDoRemove()
        {
            // TODO --> prompt user with confirmation
            throw new NotImplementedException();
        }
    }
}
