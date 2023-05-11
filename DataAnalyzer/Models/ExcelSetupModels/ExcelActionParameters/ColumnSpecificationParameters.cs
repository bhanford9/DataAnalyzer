using DataAnalyzer.Common.Mvvm;

namespace DataAnalyzer.Models.ExcelSetupModels.ExcelActionParameters;

internal class ColumnSpecificationParameters : BasePropertyChanged, IColumnSpecificationParameters
{
    private bool allColumns = true;
    private bool useColumnName = false;
    private bool useNthColumn = false;
    private bool useDataName = false;
    private string columnName = string.Empty;
    private int nthColumn = 0;
    private string dataName = string.Empty;

    public bool AllColumns
    {
        get => this.allColumns;
        set => this.NotifyPropertyChanged(ref this.allColumns, value);
    }

    public bool UseColumnName
    {
        get => this.useColumnName;
        set => this.NotifyPropertyChanged(ref this.useColumnName, value);
    }

    public bool UseNthColumn
    {
        get => this.useNthColumn;
        set => this.NotifyPropertyChanged(ref this.useNthColumn, value);
    }

    public bool UseDataName
    {
        get => this.useDataName;
        set => this.NotifyPropertyChanged(ref this.useDataName, value);
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

    public override string ToString()
    {
        string message = string.Empty;

        if (this.allColumns)
        {
            message = "All Columns";
        }
        else if (this.useColumnName)
        {
            message = $"Column: {this.columnName}";
        }
        else if (this.useNthColumn)
        {
            message = $"Column: {this.nthColumn}";
        }
        else if (this.useDataName)
        {
            message = $"Column: {this.dataName}";
        }

        return message;
    }

    public IColumnSpecificationParameters Clone() =>
        new ColumnSpecificationParameters()
        {
            AllColumns = this.allColumns,
            UseColumnName = this.useColumnName,
            UseNthColumn = this.useNthColumn,
            UseDataName = this.useDataName,
            ColumnName = this.columnName,
            NthColumn = this.nthColumn,
            DataName = this.dataName,
        };
}
