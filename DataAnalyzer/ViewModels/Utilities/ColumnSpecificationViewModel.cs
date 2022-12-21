using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.ViewModels.Utilities
{
    internal class ColumnSpecificationViewModel : BasePropertyChanged
    {
        private bool allColumns = true;
        private bool useColumnName = false;
        private bool useNthColumn = false;
        private bool useDataName = false;
        private bool columnNameEnabled = false;
        private bool nthColumnEnabled = false;
        private bool dataNameEnabled = false;
        private bool radiosEnabled = false;
        private string columnName = string.Empty;
        private int nthColumn = 0;
        private string dataName = string.Empty;

        public bool AllColumns
        {
            get => this.allColumns;
            set
            {
                this.RadiosEnabled = !value;
                this.SetAllRadiosEnabled(!value);
                this.NotifyPropertyChanged(ref this.allColumns, value);
            }
        }

        public bool UseColumnName
        {
            get => this.useColumnName;
            set
            {
                if (value)
                {
                    this.SetAllRadiosEnabled(false);
                    this.ColumnNameEnabled = true;
                }

                this.NotifyPropertyChanged(ref this.useColumnName, value);
            }
        }

        public bool UseNthColumn
        {
            get => this.useNthColumn;
            set
            {

                if (value)
                {
                    this.SetAllRadiosEnabled(false);
                    this.NthColumnEnabled = true;
                }

                this.NotifyPropertyChanged(ref this.useNthColumn, value);
            }
        }

        public bool UseDataName
        {
            get => this.useDataName;
            set
            {
                if (value)
                {
                    this.SetAllRadiosEnabled(false);
                    this.DataNameEnabled = true;
                }

                this.NotifyPropertyChanged(ref this.useDataName, value);
            }
        }

        public bool ColumnNameEnabled
        {
            get => this.columnNameEnabled;
            set => this.NotifyPropertyChanged(ref this.columnNameEnabled, value);
        }

        public bool NthColumnEnabled
        {
            get => this.nthColumnEnabled;
            set => this.NotifyPropertyChanged(ref this.nthColumnEnabled, value);
        }

        public bool DataNameEnabled
        {
            get => this.dataNameEnabled;
            set => this.NotifyPropertyChanged(ref this.dataNameEnabled, value);
        }

        public bool RadiosEnabled
        {
            get => this.radiosEnabled;
            set => this.NotifyPropertyChanged(ref this.radiosEnabled, value);
        }

        public string ColumnName
        {
            get => this.columnName;
            set => this.NotifyPropertyChanged(ref this.columnName, value);
        }

        public int NthColumn
        {
            get => this.nthColumn;
            set => this.NotifyPropertyChanged(ref this.nthColumn, value);
        }

        public string DataName
        {
            get => this.dataName;
            set => this.NotifyPropertyChanged(ref this.dataName, value);
        }

        private void SetAllRadiosEnabled(bool enabled)
        {
            this.ColumnNameEnabled = enabled;
            this.NthColumnEnabled = enabled;
            this.DataNameEnabled = enabled;
        }
    }
}
