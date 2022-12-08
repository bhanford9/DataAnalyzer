using DataAnalyzer.Services;
using System;
using System.Drawing;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
    internal class BackgroundParameters : ActionParameters
    {
        private Color backgroundColor;
        private Color patternColor;
        private FillPattern fillPattern;

        private int nth = -1;

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

        public int Nth
        {
            get => this.nth;
            set => this.NotifyPropertyChanged(ref this.nth, value);
        }

        public override ActionCategory ActionCategory => ActionCategory.BackgroundStyle;

        public override string ToString()
        {
            string str =
              $"Background Color: {this.BackgroundColor.Name}{Environment.NewLine}" +
              $"Pattern Color: {this.PatternColor.Name}{Environment.NewLine}" +
              $"Fill Pattern: {this.FillPattern}{Environment.NewLine}";

            return str + (this.Nth >= 0 ? $"Nth: {this.Nth}{Environment.NewLine}" : "");
        }
    }
}
