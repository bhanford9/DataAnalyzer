using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Models.ExcelSetupModels.ExcelServiceConfigurations;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ActionSummaryViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Summary
{
  public class DataClusterActionsSummaryModel : ActionsSummaryModel
  {
    private const string PATH_DELIMITER = "~~";
    public override ObservableCollection<ExcelAction> GetActionCollection()
    {
      return this.excelSetupModel.AvailableDataClusterActions;
    }

    public override void LoadHeirarchicalSummariesFromModel(ActionSummaryTreeViewItem baseItem)
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
                  dataClusterItem.Description = dataCluster.DataClusterActions.Select(x => x.ActionParameters.ToString()).Aggregate((a, b) => a + Environment.NewLine + b);
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

        baseItem.Children.Add(new ActionSummaryTreeViewItem()
        {
          IsLeaf = false,
          Name = workbookStats.Key.ToString(),
        });

        foreach (HeirarchalStats worksheetStats in workbookStats.Children)
        {
          path += PATH_DELIMITER + worksheetStats.Key.ToString();

          baseItem.Children.Last().Children.Add(new ActionSummaryTreeViewItem()
          {
            IsLeaf = false,
            Name = worksheetStats.Key.ToString()
          });

          foreach (HeirarchalStats dataClusters in worksheetStats.Children)
          {
            path += PATH_DELIMITER + dataClusters.Key.ToString();

            baseItem.Children.Last().Children.Last().Children.Add(new ActionSummaryTreeViewItem()
            {
              IsLeaf = true,
              Name = dataClusters.Key.ToString()
            });
          }
        }
      }
    }
  }
}
