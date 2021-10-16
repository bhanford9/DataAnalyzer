using System.ComponentModel;

namespace DataAnalyzer.Common.Mvvm
{
  public class BasePropertyChanged : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(string propertyName)
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected void NotifyPropertyChanged<T>(string propertyName, ref T property, T value)
    {
      if (!property.Equals(value))
      {
        property = value;
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
