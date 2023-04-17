using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models;
using DataAnalyzer.Models.ExcelSetupModels;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Application;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels;
using DataAnalyzer.ViewModels.Utilities;
using DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.ExcelSpecificationViewModels.Application
{
    internal class ActionApplicationViewModel : BasePropertyChanged, IActionApplicationViewModel
    {
        private readonly IStatsModel statsModel;
        private readonly IEditActionLibrary editActionLibrary;

        private readonly IActionApplicationModel actionApplicationModel;

        private IEditActionViewModel currentAction;

        private readonly BaseCommand applyAction;

        public ActionApplicationViewModel(
            IStatsModel statsModel,
            IEditActionLibrary editActionLibrary,
            ICollection<IExcelAction> actions,
            IActionApplicationModel actionApplicationModel,
            IExcelEntitySpecification excelEntityType)
        {
            this.statsModel = statsModel;
            this.actionApplicationModel = actionApplicationModel;
            ExcelEntityType = excelEntityType;
            this.editActionLibrary = editActionLibrary;

            applyAction = new BaseCommand(obj => DoApplyAction());

            EmptyParameters empty = new EmptyParameters();
            currentAction = this.editActionLibrary.GetEditAction(new EmptyParameters { ExcelEntityType = excelEntityType }, excelEntityType);
            currentAction.ActionParameters = empty;

            actions.ToList().ForEach(action =>
            {
                Actions.Add(new ActionApplicationListItemViewModel(actionApplicationModel)
                {
                    IsRemovable = false,
                    Value = action.Name,
                    ToolTipText = action.Description
                });
            });

            this.statsModel.PropertyChanged += StatsModelPropertyChanged;
            this.actionApplicationModel.PropertyChanged += ActionApplicationModelPropertyChanged;
        }

        public ObservableCollection<ICheckableTreeViewItem> WhereToApply { get; } = new();

        public ObservableCollection<ILoadableRemovableRowViewModel> Actions { get; } = new();

        public ICommand ApplyAction => applyAction;

        public IEditActionViewModel CurrentAction
        {
            get => currentAction;
            set => NotifyPropertyChanged(ref currentAction, value);
        }

        public IExcelEntitySpecification ExcelEntityType { get; }

        private ICollection<ICheckableTreeViewItem> GetFlattenedWhereToApply()
        {
            ICollection<ICheckableTreeViewItem> flattenedItems = new List<ICheckableTreeViewItem>();

            if (WhereToApply.Count > 0)
            {
                LoadIntoFlattened(WhereToApply.First(), flattenedItems);
            }

            return flattenedItems;
        }

        private void LoadIntoFlattened(ICheckableTreeViewItem baseItem, ICollection<ICheckableTreeViewItem> flattened)
        {
            foreach (ICheckableTreeViewItem child in baseItem.Children)
            {
                if (child.Children != null && child.Children.Count > 0)
                {
                    LoadIntoFlattened(child, flattened);
                }

                flattened.Add(child);
            }

            flattened.Add(baseItem);
        }

        private void DoApplyAction() => GetFlattenedWhereToApply()
              .Where(x => x.IsChecked && x.IsLeaf)
              .ToList()
              .ForEach(treeViewItem =>
              {
                  CurrentAction.ApplyParameterSettings();
                  actionApplicationModel.ApplyAction(treeViewItem, CurrentAction);
              });

        private void StatsModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(statsModel.HeirarchalStats):
                    WhereToApply.Clear();
                    WhereToApply.Add(new CheckableTreeViewItem { Name = "All Workbooks", Path = string.Empty });

                    actionApplicationModel.LoadWhereToApply(WhereToApply.First());
                    break;
            }
        }

        private void ActionApplicationModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(actionApplicationModel.LoadedActionName):
                    IExcelAction action = actionApplicationModel.GetLoadedAction();
                    CurrentAction = editActionLibrary.GetEditAction(action.ActionParameters, ExcelEntityType);
                    CurrentAction.ActionName = action.Name;
                    CurrentAction.Description = action.Description;
                    CurrentAction.ActionParameters = action.ActionParameters;
                    break;
            }
        }
    }
}
