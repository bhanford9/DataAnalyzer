using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels
{
  public class DataClusterActionApplicationModel : ActionApplicationModel
  {
    protected override ObservableCollection<ExcelAction> GetActionCollection()
    {
      return this.excelSetupModel.DataClusterActions;
    }

    protected override void InternalLoadWhereToApply(
      CheckableTreeViewItem baseItem,
      ICollection<HeirarchalStats> heirarchalStats)
    {

      // Could do a recursive approach to this in the parent if there is an abstract method 
      //   for deciding when to stop going down in depth

      foreach (HeirarchalStats workbookStats in heirarchalStats)
      {
        string path = workbookStats.Key.ToString();

        baseItem.Children.Add(new CheckableTreeViewItem()
        {
          IsChecked = true,
          Name = workbookStats.Key.ToString(),
          Path = path,
        });

        foreach (HeirarchalStats worksheetStats in workbookStats.Children)
        {
          path += PATH_DELIMITER + worksheetStats.Key.ToString();

          baseItem.Children.Last().Children.Add(new CheckableTreeViewItem()
          {
            IsChecked = true,
            Name = worksheetStats.Key.ToString(),
            Path = path
          });

          foreach (HeirarchalStats dataClusters in worksheetStats.Children)
          {
            path += PATH_DELIMITER + dataClusters.Key.ToString();

            baseItem.Children.Last().Children.Last().Children.Add(new CheckableTreeViewItem()
            {
              IsChecked = true,
              Name = dataClusters.Key.ToString(),
              Path = path,
            });
          }
        }
      }
    }
  }
}
