using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
    internal class RowActionsSummaryModel : ActionsSummaryModel, IRowActionsSummaryModel
    {
        private const string PATH_DELIMITER = "~~";

        public RowActionsSummaryModel(IStatsModel statsModel, IExcelSetupModel excelSetupModel)
            : base(statsModel, excelSetupModel)
        {
        }

        public override ObservableCollection<IExcelAction> GetActionCollection() => this.excelSetupModel.AvailableRowActions;

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
                                    //dataClusterItem.Description = dataCluster.DataClusterActions.Select(x => x.ActionParameters.ToString()).Aggregate((a, b) => a + Environment.NewLine + b);

                                    // TODO options;
                                    //  1. set the description of the data cluster to be a list of row descriptions
                                    //  2. add children to the data cluster tree view item with row descriptions
                                    //
                                    // need to better understand whether the tree view items here are directly linked to others because we don't
                                    // want to add row children to ALL of the views
                                    //
                                    // Looking at InternalLoadWhereToApply, it looks like I have independent controls which is good. either option should work
                                }
                            }
                        }
                    }
                }
            }
        }

        protected override void InternalLoadWhereToApply(IActionSummaryTreeViewItem baseItem, ICollection<IHeirarchalStats> heirarchalStats)
        {
            foreach (IHeirarchalStats workbookStats in heirarchalStats)
            {
                string path = workbookStats.Key.ToString();

                baseItem.Children.Add(new ActionSummaryTreeViewItem
                {
                    IsLeaf = false,
                    Name = workbookStats.Key.ToString(),
                    Id = "Workbook"
                });

                foreach (IHeirarchalStats worksheetStats in workbookStats.Children)
                {
                    path += PATH_DELIMITER + worksheetStats.Key.ToString();

                    baseItem.Children.Last().Children.Add(new ActionSummaryTreeViewItem
                    {
                        IsLeaf = false,
                        Name = worksheetStats.Key.ToString(),
                        Id = "Worksheet"
                    });

                    foreach (IHeirarchalStats dataClusters in worksheetStats.Children)
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
