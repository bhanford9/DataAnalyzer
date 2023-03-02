using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
    internal class RowActionsSummaryModel : ActionsSummaryModel
    {
        private const string PATH_DELIMITER = "~~";

        public override ObservableCollection<ExcelAction> GetActionCollection() => this.excelSetupModel.AvailableRowActions;

        public override void LoadHierarchicalSummariesFromModel(ActionSummaryTreeViewItem baseItem)
        {
            foreach (ActionSummaryTreeViewItem workbookItem in baseItem.Children)
            {
                WorkbookModel workbook = this.excelSetupModel.ExcelConfiguration.WorkbookModels.FirstOrDefault(x => x.Name.Equals(workbookItem.Name));

                if (workbook != default)
                {
                    foreach (ActionSummaryTreeViewItem worksheetItem in workbookItem.Children)
                    {
                        WorksheetModel worksheet = workbook.Worksheets.FirstOrDefault(x => x.WorksheetName.Equals(worksheetItem.Name));

                        if (worksheet != default)
                        {
                            foreach (ActionSummaryTreeViewItem dataClusterItem in worksheetItem.Children)
                            {
                                DataClusterModel dataCluster = worksheet.DataClusters.FirstOrDefault(x => x.Name.Equals(dataClusterItem.Name));

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

        protected override void InternalLoadWhereToApply(ActionSummaryTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats)
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
