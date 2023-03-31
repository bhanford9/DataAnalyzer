﻿using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application
{
    // This might be the same for DataClusters, Rows and Cells because Rows and Cells will be
    // visualized by having the user specify the nthRow row and nthRow col.
    // Going to skip the inheritance for now, but may need to fix it later
    internal class RowActionApplicationModel : ActionApplicationModel, IRowActionApplicationModel
    {
        private const string PATH_DELIMITER = "~~";

        public const string ACTION_APPLIED_KEY = "Row Action Applied";

        public RowActionApplicationModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
            : base(statsModel, excelSetupModel)
        {
        }

        protected override void InternalApplyAction(ICheckableTreeViewItem item, IEditActionViewModel action)
        {
            string[] pathSplit = item.Path.Split(PATH_DELIMITER);
            if (pathSplit.Length != 3)
            {
                return;
            }
            string workbookName = pathSplit[0];
            IWorkbookModel workbook = this.excelSetupModel.ExcelConfiguration.WorkbookModels.FirstOrDefault(x => x.Name.Equals(workbookName));

            if (workbook != default)
            {
                string worksheetName = pathSplit[1];
                IWorksheetModel worksheet = workbook.Worksheets.FirstOrDefault(x => x.WorksheetName.Equals(worksheetName));

                if (worksheet != default)
                {
                    IDataClusterModel dataCluster = worksheet.DataClusters.FirstOrDefault(x => x.Name.Equals(item.Name));
                    string dataClusterName = pathSplit[2];

                    if (dataCluster != default)
                    {
                        dataCluster.DataClusterActions.Add(new ExcelAction
                        {
                            ActionParameters = action.ActionParameters.Clone(),
                            Description = action.Description,
                            Name = action.ActionName
                        });

                        this.excelSetupModel.BroadcastExcelActionApplied(ACTION_APPLIED_KEY);
                    }
                    else
                    {
                        throw new Exception($"Failed to find data cluster model with name: {dataClusterName}");
                    }
                }
                else
                {
                    throw new Exception($"Failed to find worksheet model with name: {worksheetName}");
                }
            }
            else
            {
                throw new Exception($"Failed to find workbook model with name: {workbookName}");
            }
        }

        protected override ObservableCollection<IExcelAction> GetActionCollection() => this.excelSetupModel.AvailableRowActions;

        protected override void InternalLoadWhereToApply(ICheckableTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats)
        {
            foreach (HeirarchalStats workbookStats in heirarchalStats)
            {
                string workbookPath = workbookStats.Key.ToString();

                baseItem.Children.Add(new CheckableTreeViewItem
                {
                    IsChecked = true,
                    IsLeaf = false,
                    Name = workbookStats.Key.ToString(),
                    Path = workbookPath,
                });

                foreach (HeirarchalStats worksheetStats in workbookStats.Children)
                {
                    string worksheetPath = workbookPath + PATH_DELIMITER + worksheetStats.Key.ToString();

                    baseItem.Children.Last().Children.Add(new CheckableTreeViewItem
                    {
                        IsChecked = true,
                        IsLeaf = false,
                        Name = worksheetStats.Key.ToString(),
                        Path = worksheetPath
                    });

                    foreach (HeirarchalStats dataClusters in worksheetStats.Children)
                    {
                        string dataClusterPath = worksheetPath + PATH_DELIMITER + dataClusters.Key.ToString();

                        baseItem.Children.Last().Children.Last().Children.Add(new CheckableTreeViewItem
                        {
                            IsChecked = true,
                            IsLeaf = true,
                            Name = dataClusters.Key.ToString(),
                            Path = dataClusterPath,
                        });
                    }
                }
            }
        }
    }
}
