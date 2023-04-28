using DataAnalyzer.Models.ExcelSetupModels.ExcelActionModels.Creation;
using DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;
using DataAnalyzer.Services;
using DataAnalyzer.Services.Enums;
using DataAnalyzer.Services.ExcelUtilities;
using DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.SubModelConversions;
using DataAnalyzer.ViewModels.Utilities;
using System;
using System.Collections.ObjectModel;

namespace DataAnalyzer.ViewModels.ExcelSetupViewModels.ExcelActionViewModels.EditActionViewModels
{
    internal class AlignmentEditViewModel : EditActionViewModel, IAlignmentEditViewModel
    {
        private string selectedHorizontalAlignment = string.Empty;
        private string selectedVerticalAlignment = string.Empty;
        private IRowSpecificationViewModel rowSpecification;
        private IColumnSpecificationViewModel columnSpecification;

        private readonly EnumUtilities enumUtilities = new();

        public AlignmentEditViewModel(IExcelEntitySpecification excelEntityType)
            : base(excelEntityType)
        {
        }

        public AlignmentEditViewModel(
            IActionCreationModel actionCreationModel,
            IEditActionViewModel toCopy,
            IExcelEntitySpecification excelEntityType,
            IRowSpecificationViewModel rowSpecification,
            IColumnSpecificationViewModel columnSpecification)
          : base(actionCreationModel, toCopy, excelEntityType)
        {
            this.rowSpecification = rowSpecification;
            this.columnSpecification = columnSpecification;
        }

        public ObservableCollection<string> HorizontalAlignments { get; } = new();

        public ObservableCollection<string> VerticalAlignments { get; } = new();

        public string SelectedHorizontalAlignment
        {
            get => this.selectedHorizontalAlignment;
            set => this.NotifyPropertyChanged(ref this.selectedHorizontalAlignment, value);
        }

        public string SelectedVerticalAlignment
        {
            get => this.selectedVerticalAlignment;
            set => this.NotifyPropertyChanged(ref this.selectedVerticalAlignment, value);
        }

        public IRowSpecificationViewModel RowSpecification
        {
            get => this.rowSpecification;
            set => this.NotifyPropertyChanged(ref this.rowSpecification, value);
        }

        public IColumnSpecificationViewModel ColumnSpecification
        {
            get => this.columnSpecification;
            set => this.NotifyPropertyChanged(ref this.columnSpecification, value);
        }

        public override IEditActionViewModel GetNewInstance(IActionParameters parameters)
        {
            AlignmentEditViewModel viewModel = new(
                this.actionCreationModel,
                this,
                this.ExcelEntityType,
                this.rowSpecification,
                this.columnSpecification);

            AlignmentParameters alignmentParameters = parameters as AlignmentParameters;
            viewModel.SelectedHorizontalAlignment = alignmentParameters.HorizontalAlignment.ToString();
            viewModel.SelectedVerticalAlignment = alignmentParameters.VerticalAlignment.ToString();
            viewModel.ColumnSpecification = ColumnSpecificationConversion.ToViewModel(alignmentParameters.ColumnSpecification);
            viewModel.RowSpecification = RowSpecificationConversion.ToViewModel(alignmentParameters.RowSpecification);
            return viewModel;
        }

        public override void ApplyParameterSettings()
        {
            AlignmentParameters alignmentParameters = this.ActionParameters as AlignmentParameters;
            alignmentParameters.HorizontalAlignment = Enum.Parse<HorizontalAlignment>(this.SelectedHorizontalAlignment);
            alignmentParameters.VerticalAlignment = Enum.Parse<VerticalAlignment>(this.SelectedVerticalAlignment);
            alignmentParameters.ColumnSpecification = ColumnSpecificationConversion.ToModel(this.ColumnSpecification);
            alignmentParameters.RowSpecification = RowSpecificationConversion.ToModel(this.RowSpecification);
        }

        protected override bool InternalIsApplicable(IActionParameters parameters) => parameters is AlignmentParameters;

        protected override void DoAct() => throw new NotImplementedException();

        protected override void InternalInit(IEditActionViewModel toCopy)
        {
            this.enumUtilities.LoadNames(typeof(HorizontalAlignment), this.HorizontalAlignments);
            this.enumUtilities.LoadNames(typeof(VerticalAlignment), this.VerticalAlignments);
        }
    }
}
