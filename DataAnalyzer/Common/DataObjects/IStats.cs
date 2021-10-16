using DataAnalyzer.Services;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataObjects
{
  public interface IStats
  {
    string Uid { get; }
    ICollection<string> ParameterNames { get; }

    T GetEnumeratedParameters<T>();
  }
}
