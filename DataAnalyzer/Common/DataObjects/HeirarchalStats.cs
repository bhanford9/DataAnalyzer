using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataObjects
{
  public class HeirarchalStats : Stats
  {
    public IComparable Key { get; set; }

    public ICollection<IStats> Values { get; set; } = new List<IStats>();

    public ICollection<HeirarchalStats> Children { get; set; } = new List<HeirarchalStats>();

    public override ICollection<string> ParameterNames
    {
      get
      {
        if (this.Values.Count > 0)
        {
          return this.Values.ElementAt(0).ParameterNames;
        }

        if (this.Children.Count > 0)
        {
          return this.Children.ElementAt(0).ParameterNames;
        }

        return new List<string>();
      }
    }

    public override T GetEnumeratedParameters<T>()
    {
      if (this.Values.Count > 0)
      {
        return this.Values.ElementAt(0).GetEnumeratedParameters<T>();
      }

      if (this.Children.Count > 0)
      {
        return this.Children.ElementAt(0).GetEnumeratedParameters<T>();
      }

      return default;
    }
  }
}
