﻿using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services.Enums;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal abstract class EditActionViewModel : BasePropertyChanged, IEditActionViewModel
    {
        protected IActionCreationModel actionCreationModel;

        private string actionName = string.Empty;
        private string description = string.Empty;
        private IActionParameters actionParameters;

        private readonly BaseCommand act;

        public EditActionViewModel(IActionCreationModel actionCreationModel, ExcelEntityType excelEntityType)
            : this(excelEntityType)
        {
            this.actionCreationModel = actionCreationModel;

            this.act = new BaseCommand(obj => this.DoAct());
        }

        public EditActionViewModel(
          IActionCreationModel actionCreationModel,
          IEditActionViewModel toCopy,
          ExcelEntityType excelEntityType)
          : this(actionCreationModel, excelEntityType)
        {
            this.ActionName = toCopy.ActionName;
            this.Description = toCopy.Description;

            this.InternalInit(toCopy);

            // TODO --> Setup events
            //   This will make sure the original does not have events, but children do
        }

        protected EditActionViewModel(ExcelEntityType excelEntityType)
        {
            this.ExcelEntityType = excelEntityType;
        }

        public ICommand Act => this.act;

        public ExcelEntityType ExcelEntityType { get; }

        public string ActionName
        {
            get => this.actionName;
            set => this.NotifyPropertyChanged(ref this.actionName, value);
        }

        public string Description
        {
            get => this.description;
            set => this.NotifyPropertyChanged(ref this.description, value);
        }

        public IActionParameters ActionParameters
        {
            get => this.actionParameters;
            set => this.NotifyPropertyChanged(ref this.actionParameters, value);
        }

        public bool IsApplicable(IActionParameters parameters) => this.InternalIsApplicable(parameters) && this.ExcelEntityType.Equals(parameters.ExcelEntityType);

        protected abstract bool InternalIsApplicable(IActionParameters parameters);

        public abstract IEditActionViewModel GetNewInstance(IActionParameters parameters);

        public abstract void ApplyParameterSettings();

        protected abstract void InternalInit(IEditActionViewModel toCopy);

        protected abstract void DoAct();
    }
}
