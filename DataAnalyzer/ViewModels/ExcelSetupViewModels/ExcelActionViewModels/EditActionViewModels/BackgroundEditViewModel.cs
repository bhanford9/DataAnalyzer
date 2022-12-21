using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.SubModelConversions;
using DataAnalyzer.ViewModels.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal class BackgroundEditViewModel : EditActionViewModel
    {
        private string selectedPattern = string.Empty;
        private readonly EnumUtilities enumUtilities = new();
        private RowSpecificationViewModel rowSpecification = new();
        private ColumnSpecificationViewModel columnSpecification = new();

        public BackgroundEditViewModel(ExcelEntityType excelEntityType)
            : base(excelEntityType)
        {
        }

        public BackgroundEditViewModel(
            IActionCreationModel actionCreationModel,
            IEditActionViewModel toCopy,
            ExcelEntityType excelEntityType)
          : base(actionCreationModel, toCopy, excelEntityType)
        {
        }

        public ObservableCollection<string> Patterns { get; } = new();

        public ColorsComboBoxViewModel BackgroundColors { get; } = new();

        public ColorsComboBoxViewModel PatternColors { get; } = new();

        public string SelectedPattern
        {
            get => this.selectedPattern;
            set => this.NotifyPropertyChanged(ref this.selectedPattern, value);
        }

        public RowSpecificationViewModel RowSpecification
        {
            get => this.rowSpecification;
            set => this.NotifyPropertyChanged(ref this.rowSpecification, value);
        }

        public ColumnSpecificationViewModel ColumnSpecification
        {
            get => this.columnSpecification;
            set => this.NotifyPropertyChanged(ref this.columnSpecification, value);
        }

        public override void ApplyParameterSettings()
        {
            BackgroundParameters backgroundParameters = this.ActionParameters as BackgroundParameters;
            backgroundParameters.BackgroundColor = Color.FromName(this.BackgroundColors.SelectedColor);
            backgroundParameters.PatternColor = Color.FromName(this.PatternColors.SelectedColor);
            backgroundParameters.FillPattern = Enum.Parse<FillPattern>(this.SelectedPattern);
            backgroundParameters.ColumnSpecification = ColumnSpecificationConversion.ToModel(this.ColumnSpecification);
            backgroundParameters.RowSpecification = RowSpecificationConversion.ToModel(this.RowSpecification);
        }

        public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
        {
            BackgroundEditViewModel viewModel = new(this.actionCreationModel, this, this.ExcelEntityType);
            BackgroundParameters backgroundParameters = parameters as BackgroundParameters;
            viewModel.BackgroundColors.SelectedColor = backgroundParameters.BackgroundColor.Name;
            viewModel.PatternColors.SelectedColor = backgroundParameters.PatternColor.Name;
            viewModel.SelectedPattern = backgroundParameters.FillPattern.ToString();
            viewModel.ColumnSpecification = ColumnSpecificationConversion.ToViewModel(backgroundParameters.ColumnSpecification);
            viewModel.RowSpecification = RowSpecificationConversion.ToViewModel(backgroundParameters.RowSpecification);
            return viewModel;
        }

        protected override bool InternalIsApplicable(IActionParameters parameters)
        {
            return parameters is BackgroundParameters;
        }

        protected override void DoAct()
        {
            throw new NotImplementedException();
        }

        protected override void InternalInit(IEditActionViewModel toCopy)
        {
            this.enumUtilities.LoadNames(typeof(FillPattern), this.Patterns);
        }
    }
}
