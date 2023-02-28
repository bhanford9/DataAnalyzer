using DataAnalyzer.Services.Enums;
using System;
using System.Drawing;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
    internal class BackgroundParameters : ActionParameters
    {
        private Color backgroundColor;
        private Color patternColor;
        private FillPattern fillPattern;
        private ColumnSpecificationParameters columnSpecification = new();
        private RowSpecificationParameters rowSpecification = new();

        public Color BackgroundColor
        {
            get => this.backgroundColor;
            set => this.NotifyPropertyChanged(ref this.backgroundColor, value);
        }

        public Color PatternColor
        {
            get => this.patternColor;
            set => this.NotifyPropertyChanged(ref this.patternColor, value);
        }

        public FillPattern FillPattern
        {
            get => this.fillPattern;
            set => this.NotifyPropertyChanged(ref this.fillPattern, value);
        }

        public ColumnSpecificationParameters ColumnSpecification
        {
            get => this.columnSpecification;
            set => this.NotifyPropertyChanged(ref this.columnSpecification, value);
        }

        public RowSpecificationParameters RowSpecification
        {
            get => this.rowSpecification;
            set => this.NotifyPropertyChanged(ref this.rowSpecification, value);
        }

        public override ActionCategory ActionCategory => ActionCategory.BackgroundStyle;

        public override string ToString() =>
            $"Background Color: {this.BackgroundColor.Name}{Environment.NewLine}" +
            $"Pattern Color: {this.PatternColor.Name}{Environment.NewLine}" +
            $"Fill Pattern: {this.FillPattern}{Environment.NewLine}" +
            $"{ColumnSpecification}{Environment.NewLine}" +
            $"{RowSpecification}{Environment.NewLine}";

        public override IActionParameters Clone() =>
            new BackgroundParameters
            {
                ExcelEntityType = this.ExcelEntityType,
                Name = this.Name,
                BackgroundColor = this.backgroundColor,
                PatternColor = this.patternColor,
                FillPattern = this.fillPattern,
                ColumnSpecification = this.columnSpecification.Clone(),
                RowSpecification = this.rowSpecification.Clone(),
            };
    }
}
