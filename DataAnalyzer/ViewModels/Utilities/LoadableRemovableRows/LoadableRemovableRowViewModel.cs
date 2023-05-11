using DataAnalyzer.Common.Mvvm;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.Utilities.LoadableRemovableRows;

internal abstract class LoadableRemovableRowViewModel : RowViewModel, ILoadableRemovableRowViewModel
{
    private string toolTipText = string.Empty;
    private bool isRemovable = true;

    private readonly BaseCommand remove;
    private readonly BaseCommand load;

    public LoadableRemovableRowViewModel()
    {
        this.remove = new BaseCommand(obj => this.DoRemove());
        this.load = new BaseCommand(obj => this.DoLoad());
    }

    public ICommand Remove => this.remove;
    public ICommand Load => this.load;

    public string ToolTipText
    {
        get => this.toolTipText;
        set => this.NotifyPropertyChanged(ref this.toolTipText, value);
    }

    public bool IsRemovable
    {
        get => this.isRemovable;
        set => this.NotifyPropertyChanged(ref this.isRemovable, value);
    }

    protected void DoRemove()
    {
        if (this.isRemovable)
        {
            this.InternalDoRemove();
        }
    }

    protected abstract void InternalDoRemove();

    protected abstract void DoLoad();
}
