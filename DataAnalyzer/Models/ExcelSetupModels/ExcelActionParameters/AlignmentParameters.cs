using DataAnalyzer.Services.Enums;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
    internal class AlignmentParameters : ActionParameters, IAlignmentParameters
    {
        private HorizontalAlignment horizontalAlignment = HorizontalAlignment.General;
        private VerticalAlignment verticalAlignment = VerticalAlignment.Top;
        private IColumnSpecificationParameters columnSpecification = new ColumnSpecificationParameters();
        private IRowSpecificationParameters rowSpecification = new RowSpecificationParameters();

        public HorizontalAlignment HorizontalAlignment
        {
            get => this.horizontalAlignment;
            set => this.NotifyPropertyChanged(ref this.horizontalAlignment, value);
        }

        public VerticalAlignment VerticalAlignment
        {
            get => this.verticalAlignment;
            set => this.NotifyPropertyChanged(ref this.verticalAlignment, value);
        }

        public IColumnSpecificationParameters ColumnSpecification
        {
            get => this.columnSpecification;
            set => this.NotifyPropertyChanged(ref this.columnSpecification, value);
        }

        public IRowSpecificationParameters RowSpecification
        {
            get => this.rowSpecification;
            set => this.NotifyPropertyChanged(ref this.rowSpecification, value);
        }

        public override ActionCategory ActionCategory => ActionCategory.AlignmentStyle;

        public override string ToString() =>
            $"Horizontal Alignment: {this.HorizontalAlignment}{Environment.NewLine}" +
            $"Vertical Alignment: {this.VerticalAlignment}{Environment.NewLine}" +
            $"{this.ColumnSpecification}{Environment.NewLine}" +
            $"{this.RowSpecification}{Environment.NewLine}";

        public override IActionParameters Clone() =>
            new AlignmentParameters
            {
                ExcelEntityType = this.ExcelEntityType,
                Name = this.Name,
                HorizontalAlignment = this.HorizontalAlignment,
                VerticalAlignment = this.VerticalAlignment,
                ColumnSpecification = this.ColumnSpecification.Clone(),
                RowSpecification = this.RowSpecification.Clone()
            };
    }
}
