﻿using System.Collections.ObjectModel;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation
{
    internal class DataClusterActionCreationModel : ActionCreationModel
    {
        protected override ObservableCollection<ExcelAction> GetActionCollection()
        {
            return this.excelSetupModel.AvailableDataClusterActions;
        }
    }
}
