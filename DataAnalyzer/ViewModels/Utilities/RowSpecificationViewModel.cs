using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.ViewModels.Utilities
{
    class RowSpecificationViewModel : BasePropertyChanged, IRowSpecificationViewModel
    {
        private bool allRows = true;
        private bool useNthRow = false;
        private bool nthRowEnabled = false;
        private int nthRow = 0;

        public bool AllRows
        {
            get => this.allRows;
            set
            {
                this.SetAllRadiosEnabled(!value);
                this.NotifyPropertyChanged(ref this.allRows, value);
            }
        }

        public bool UseNthRow
        {
            get => this.useNthRow;
            set
            {
                if (value)
                {
                    this.SetAllRadiosEnabled(false);
                    this.NthRowEnabled = true;
                }

                this.NotifyPropertyChanged(ref this.useNthRow, value);
            }
        }

        public bool NthRowEnabled
        {
            get => this.nthRowEnabled;
            set => this.NotifyPropertyChanged(ref this.nthRowEnabled, value);
        }

        public int NthRow
        {
            get => this.nthRow;
            set => this.NotifyPropertyChanged(ref this.nthRow, value);
        }

        private void SetAllRadiosEnabled(bool enabled)
        {
            this.NthRowEnabled = enabled;
            this.UseNthRow = enabled;
        }
    }
}
