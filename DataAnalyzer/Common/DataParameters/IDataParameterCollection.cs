﻿using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Services;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataParameters
{
  public interface IDataParameterCollection
  {
    StatType StatType { get; }

    ICollection<string> GetGroupableParameterNames();
    ICollection<IDataParameter> GetGroupableParameters();
    ICollection<IDataParameter> GetParameters();
    ICollection<string> GetSortableParameterNames();
    ICollection<IDataParameter> GetSortableParameters();
    Func<IStats, IComparable> GetStatAccessor(string name);
  }
}