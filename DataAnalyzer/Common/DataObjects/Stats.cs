using System;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataObjects
{
  public abstract class Stats : IStats
  {
    private readonly string uid = Guid.NewGuid().ToString();

    public string Uid => this.uid;

    public abstract ICollection<string> ParameterNames { get; }

    public abstract T GetEnumeratedParameters<T>();
  }
}
