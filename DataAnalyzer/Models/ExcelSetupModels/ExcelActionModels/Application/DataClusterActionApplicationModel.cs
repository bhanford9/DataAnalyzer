using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application
{
  public class DataClusterActionApplicationModel : ActionApplicationModel
  {
    private const string PATH_DELIMITER = "~~";

    protected override ObservableCollection<ExcelAction> GetActionCollection()
    {
      return this.excelSetupModel.DataClusterActions;
    }

    protected override void InternalLoadWhereToApply(CheckableTreeViewItem baseItem, ICollection<HeirarchalStats> heirarchalStats)
    {
      foreach (HeirarchalStats workbookStats in heirarchalStats)
      {
        string path = workbookStats.Key.ToString();

        baseItem.Children.Add(new CheckableTreeViewItem()
        {
          IsChecked = true,
          IsLeaf = false,
          Name = workbookStats.Key.ToString(),
          Path = path,
        });

        foreach (HeirarchalStats worksheetStats in workbookStats.Children)
        {
          path += PATH_DELIMITER + worksheetStats.Key.ToString();

          baseItem.Children.Last().Children.Add(new CheckableTreeViewItem()
          {
            IsChecked = true,
            IsLeaf = false,
            Name = worksheetStats.Key.ToString(),
            Path = path
          });

          foreach (HeirarchalStats dataClusters in worksheetStats.Children)
          {
            path += PATH_DELIMITER + dataClusters.Key.ToString();

            baseItem.Children.Last().Children.Last().Children.Add(new CheckableTreeViewItem()
            {
              IsChecked = true,
              IsLeaf = true,
              Name = dataClusters.Key.ToString(),
              Path = path,
            });
          }
        }
      }
    }
  }
}
