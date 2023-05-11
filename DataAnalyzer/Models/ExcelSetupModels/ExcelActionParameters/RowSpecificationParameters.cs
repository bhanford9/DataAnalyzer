using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

internal class RowSpecificationParameters : BasePropertyChanged, IRowSpecificationParameters
{
    private bool allRows = true;
    private bool useNthRow = false;
    private int nthRow = 0;

    public bool AllRows
    {
        get => this.allRows;
        set => this.NotifyPropertyChanged(ref this.allRows, value);
    }

    public bool UseNthRow
    {
        get => this.useNthRow;
        set => this.NotifyPropertyChanged(ref this.useNthRow, value);
    }

    public int NthRow
    {
        get => this.nthRow;
        set => this.NotifyPropertyChanged(ref this.nthRow, value);
    }

    public override string ToString()
    {
        string message = string.Empty;

        if (this.allRows)
        {
            message = "All Rows";
        }
        else if (this.useNthRow)
        {
            message = $"Row: {this.nthRow}";
        }

        return message;
    }

    public IRowSpecificationParameters Clone() =>
        new RowSpecificationParameters()
        {
            AllRows = this.allRows,
            UseNthRow = this.useNthRow,
            NthRow = this.nthRow,
        };
}
