using DataAnalyzer.Common.DataObjects;
using System;

namespace DataAnalyzer.Common.DataParameters
{
  public interface IDataParameter
  {
    bool CanGroupBy { get; set; }
    bool CanSortBy { get; set; }
    string Name { get; set; }
    Func<IStats, IComparable> StatAccessor { get; }
  }
}