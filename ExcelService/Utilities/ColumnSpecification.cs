namespace ExcelService.Utilities
{
    internal class ColumnSpecification : IColumnSpecification
    {
        private int nthColumn = 0;
        private string columnAddress = "A";
        private string columnHeader = string.Empty;

        public int NthColumn
        {
            get => nthColumn;
            set
            {
                nthColumn = value;
                SetAllUses();
                UseNthColumn = true;
            }
        }

        public string ColumnAddress
        {
            get => columnAddress;
            set
            {
                columnAddress = value;
                SetAllUses();
                UseColumnAddress = true;
            }
        }

        public string ColumnHeader
        {
            get => columnHeader;
            set
            {
                columnHeader = value;
                SetAllUses();
                UseColumnHeader = true;
            }
        }

        public bool UseNthColumn { get; private set; } = false;

        public bool UseColumnAddress { get; private set; } = false;

        public bool UseColumnHeader { get; private set; } = false;

        private void SetAllUses(bool use = false)
        {
            UseNthColumn = use;
            UseColumnAddress = use;
            UseColumnHeader = use;
        }
    }
}
