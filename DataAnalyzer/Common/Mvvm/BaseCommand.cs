using System;
using System.Windows.Input;

namespace DataAnalyzer.Common.Mvvm
{
  public class BaseCommand : ICommand
  {
    private readonly Predicate<object> canExecute;
    private readonly Action<object> execute;

    public BaseCommand(Action<object> execute, Predicate<object> canExecute = null)
    {
      this.canExecute = canExecute;
      this.execute = execute;
    }

    public event EventHandler CanExecuteChanged;

    public void RaiseCanExecuteChanged()
    {
      if (this.CanExecuteChanged != null)
      {
        this.CanExecuteChanged(this, EventArgs.Empty);
      }
    }

    public bool CanExecute(object parameter)
    {
      return this.canExecute?.Invoke(parameter) ?? true;
    }

    public void Execute(object parameter)
    {
      this.execute?.Invoke(parameter);
    }
  }
}
