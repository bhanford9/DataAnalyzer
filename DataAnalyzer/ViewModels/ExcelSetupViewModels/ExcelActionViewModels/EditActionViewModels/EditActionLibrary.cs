using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
  public class EditActionLibrary
  {
    private readonly ICollection<IEditActionViewModel> editActionViewModels = new List<IEditActionViewModel>();

    public EditActionLibrary()
    {
      this.LoadItems();
    }

    public IEditActionViewModel GetEditAction(IActionParameters actionParameters)
    {
      return this.editActionViewModels
        .FirstOrDefault(x => x.IsApplicable(actionParameters))
        .GetNewInstance(actionParameters);
    }

    private void LoadItems()
    {
      this.editActionViewModels.Add(new EmptyEditViewModel());

      this.editActionViewModels.Add(new AlignmentEditViewModel());
      this.editActionViewModels.Add(new BackgroundEditViewModel());
      this.editActionViewModels.Add(new BorderEditViewModel());
      this.editActionViewModels.Add(new BooleanActionViewModel());
    }
  }
}
