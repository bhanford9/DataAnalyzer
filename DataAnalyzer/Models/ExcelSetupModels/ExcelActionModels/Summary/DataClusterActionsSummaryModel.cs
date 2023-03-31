using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
    internal class DataClusterActionsSummaryModel : ActionsSummaryModel, IDataClusterActionsSummaryModel
    {
        private const string PATH_DELIMITER = "~~";

        public DataClusterActionsSummaryModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
            : base(statsModel, excelSetupModel)
        {
        }

        public override ObservableCollection<IExcelAction> GetActionCollection() => this.excelSetupModel.AvailableDataClusterActions;

        public override void LoadHierarchicalSummariesFromModel(IActionSummaryTreeViewItem baseItem)
        {
            foreach (IActionSummaryTreeViewItem workbookItem in baseItem.Children)
            {
                IWorkbookModel workbook = this.excelSetupModel.ExcelConfiguration.WorkbookModels.FirstOrDefault(x => x.Name.Equals(workbookItem.Name));

                if (workbook != default)
                {
                    foreach (IActionSummaryTreeViewItem worksheetItem in workbookItem.Children)
                    {
                        IWorksheetModel worksheet = workbook.Worksheets.FirstOrDefault(x => x.WorksheetName.Equals(worksheetItem.Name));

                        if (worksheet != default)
                        {
                            foreach (IActionSummaryTreeViewItem dataClusterItem in worksheetItem.Children)
                            {
                                IDataClusterModel dataCluster = worksheet.DataClusters.FirstOrDefault(x => x.Name.Equals(dataClusterItem.Name));

                                if (dataCluster != default && dataCluster.DataClusterActions.Count > 0)
                                {
                                    dataClusterItem.SummaryViewModels.Clear();

                                    foreach (IExcelAction action in dataCluster.DataClusterActions)
                                    {
                                        dataClusterItem.SummaryViewModels.Add(new ActionSummaryExpandableViewModel
                                        {
                                            PathId = $"{workbookItem.Name}.{worksheetItem.Name}.{dataClusterItem.Name}",
                                            ActionName = $"{action.Name}",
                                            ActionDescription = $"{action.Description}",
                                            DescriptionPreview = $"{action.ActionParameters.Name}", // TBD
                                            DetailedDescription = $"{action.ActionParameters}",
                                        });
                                    }

                                    dataClusterItem.Description = dataCluster.DataClusterActions.Select(x => x.ActionParameters.ToString()).Aggregate((a, b) => a + Environment.NewLine + b);
                                }
                            }
                        }
                    }
                }
            }
        }

        protected override void InternalLoadWhereToApply(IActionSummaryTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats)
        {
            foreach (HeirarchalStats workbookStats in heirarchalStats)
            {
                string path = workbookStats.Key.ToString();

                baseItem.Children.Add(new ActionSummaryTreeViewItem
                {
                    IsLeaf = false,
                    Name = workbookStats.Key.ToString(),
                    Id = "Workbook"
                });

                foreach (HeirarchalStats worksheetStats in workbookStats.Children)
                {
                    path += PATH_DELIMITER + worksheetStats.Key.ToString();

                    baseItem.Children.Last().Children.Add(new ActionSummaryTreeViewItem
                    {
                        IsLeaf = false,
                        Name = worksheetStats.Key.ToString(),
                        Id = "Worksheet"
                    });

                    foreach (HeirarchalStats dataClusters in worksheetStats.Children)
                    {
                        path += PATH_DELIMITER + dataClusters.Key.ToString();

                        baseItem.Children.Last().Children.Last().Children.Add(new ActionSummaryTreeViewItem
                        {
                            IsLeaf = true,
                            Name = dataClusters.Key.ToString(),
                            Id = "Data Cluster"
                        });
                    }
                }
            }
        }
    }
}
