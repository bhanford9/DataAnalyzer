using DataAnalyzer.Services;
using System;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters
{
    internal class AlignmentParameters : ActionParameters
    {
        private HorizontalAlignment horizontalAlignment = HorizontalAlignment.General;
        private VerticalAlignment verticalAlignment = VerticalAlignment.Top;
        private int nth = -1;

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

        public int Nth
        {
            get => this.nth;
            set => this.NotifyPropertyChanged(ref this.nth, value);
        }

        public override ActionCategory ActionCategory => ActionCategory.AlignmentStyle;

        public override string ToString()
        {
            string str =
              $"Horizontal Alignment: {this.HorizontalAlignment}{Environment.NewLine}" +
              $"Vertical Alignment: {this.VerticalAlignment}{Environment.NewLine}";

            return str + (this.Nth >= 0 ? $"Nth: {this.Nth}{Environment.NewLine}" : "");
        }
    }
}
