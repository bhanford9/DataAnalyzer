using System;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataObjects
{
  public class HeirarchalStats : Stats
  {
    public IComparable Key { get; set; }

    public ICollection<IStats> Values { get; set; } = new List<IStats>();

    public ICollection<HeirarchalStats> Children { get; set; } = new List<HeirarchalStats>();
  }
}
