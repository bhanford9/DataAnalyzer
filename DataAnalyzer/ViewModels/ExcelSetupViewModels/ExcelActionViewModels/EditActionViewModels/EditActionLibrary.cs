using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services.ExcelUtilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal class EditActionLibrary : IEditActionLibrary
    {
        private readonly IReadOnlyCollection<Func<IExcelEntitySpecification, IEditActionViewModel>> editActionViewModels;

        // TODO --> this is now a factory instead of a library
        public EditActionLibrary(ICollection<Func<IExcelEntitySpecification, IEditActionViewModel>> editActionViewModels)
        {
            this.editActionViewModels = editActionViewModels.ToList();

            // TODO --> this will need to go into the container
            //    = new List<Func<IExcelEntitySpecification, IEditActionViewModel>>
            //{
            //    x => new EmptyEditViewModel(x),
            //    x => new AlignmentEditViewModel(x),
            //    x => new BackgroundEditViewModel(x),
            //    x => new BorderEditViewModel(x),
            //    x => new BooleanActionViewModel(x),
            //};
        }

        public IEditActionViewModel GetEditAction(IActionParameters actionParameters, IExcelEntitySpecification excelEntityType) =>
            // this is expensive, but I don't really care. Only doing it this way to support 1-to-many relationship between
            // parameter type and view model. If that is not needed, then this can be simplified & optimized to a dictionary
            this.editActionViewModels
              .FirstOrDefault(x => x(excelEntityType).IsApplicable(actionParameters))
              .Invoke(excelEntityType).GetNewInstance(actionParameters); // GetNewInstance could probably just be moved into the constructor
    }
}
