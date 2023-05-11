using DataAnalyzer.Common.Mvvm;
using DataAnalyzer.Services.ClassGenerationServices;
using DataAnalyzer.ViewModels.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DataAnalyzer.ViewModels.ExecutionViewModels;

internal class ClassSetupBoxViewModel : BasePropertyChanged, IClassSetupBoxViewModel
{
    private string className = string.Empty;
    private string classAccessibility = string.Empty;
    private string applyToAllType = string.Empty;
    private string applyToAllAccessibility = string.Empty;

    private readonly BaseCommand applyToAll;

    public ClassSetupBoxViewModel()
    {
        this.applyToAll = new BaseCommand(_ => this.DoApplyToAll());
    }

    public ICommand ApplyToAll => this.applyToAll;

    public ObservableCollection<IPropertyData> Properties { get; init; } = new ();

    public IReadOnlyCollection<string> Types { get; } = new[]
    {
        ClassCreationConstants.BOOL_TYPE_DISPLAY,
        ClassCreationConstants.INT_TYPE_DISPLAY,
        ClassCreationConstants.DOUBLE_TYPE_DISPLAY,
        ClassCreationConstants.STRING_TYPE_DISPLAY,
        ClassCreationConstants.DATE_TIME_TYPE_DISPLAY,
        ClassCreationConstants.BYTE_TYPE_DISPLAY,
        ClassCreationConstants.SBYTE_TYPE_DISPLAY,
        ClassCreationConstants.CHAR_TYPE_DISPLAY,
        ClassCreationConstants.DECIMAL_TYPE_DISPLAY,
        ClassCreationConstants.FLOAT_TYPE_DISPLAY,
        ClassCreationConstants.UINT_TYPE_DISPLAY,
        ClassCreationConstants.NINT_TYPE_DISPLAY,
        ClassCreationConstants.NUINT_TYPE_DISPLAY,
        ClassCreationConstants.LONG_TYPE_DISPLAY,
        ClassCreationConstants.ULONG_TYPE_DISPLAY,
        ClassCreationConstants.SHORT_TYPE_DISPLAY,
        ClassCreationConstants.USHORT_TYPE_DISPLAY,
    };

    public IReadOnlyCollection<string> BaseAccessibilities { get; } = new[]
    {
        ClassCreationConstants.PUBLIC_ACCESS_DISPLAY,
        ClassCreationConstants.INTERNAL_ACCESS_DISPLAY,
        ClassCreationConstants.PROTECTED_ACCESS_DISPLAY,
        ClassCreationConstants.PRIVATE_ACCESS_DISPLAY,
    };

    public IReadOnlyCollection<string> PropertyAccessibilities { get; } = new[]
    {
        ClassCreationConstants.READ_ONLY,
        ClassCreationConstants.READ_INIT,
        ClassCreationConstants.READ_PRIVATE_WRITE,
        ClassCreationConstants.READ_PROTECTED_WRITE,
        ClassCreationConstants.READ_WRITE,
    };

    public string ClassName
    {
        get => this.className;
        set => this.NotifyPropertyChanged(ref this.className, value);
    }

    public string ClassAccessibility
    {
        get => this.classAccessibility;
        set => this.NotifyPropertyChanged(ref this.classAccessibility, value);
    }

    public string ApplyToAllType
    {
        get => this.applyToAllType;
        set => this.NotifyPropertyChanged(ref this.applyToAllType, value);
    }

    public string ApplyToAllAccessibility
    {
        get => this.applyToAllAccessibility;
        set => this.NotifyPropertyChanged(ref this.applyToAllAccessibility, value);
    }

    private void DoApplyToAll()
    {

    }
}
