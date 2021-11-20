using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAnalyzer.Services
{
  public class EnumUtilities
  {
    public void LoadNames(Type type, ICollection<string> collection)
    {
      Enum.GetNames(type).ToList().ForEach(x => collection.Add(x));
    }

    public void LoadValues<T>(Type type, ICollection<T> collection)
    {
      foreach (T value in Enum.GetValues(type))
      {
        collection.Add(value);
      }
    }
  }
}
