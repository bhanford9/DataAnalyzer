using DataAnalyzer.DataImport.DataObjects;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataParameters;

internal interface IStatAccessorCollection
{
    //IReadOnlyCollection<string> GetGroupableParameterNames();
    //IReadOnlyCollection<IStatAccessor<IStats>> GetGroupableParameters();
    IReadOnlyCollection<IStatAccessor<IStats>> GetStatAccessors();
    //IReadOnlyCollection<string> GetSortableParameterNames();
    //IReadOnlyCollection<IStatAccessor<IStats>> GetSortableParameters();
    Func<IStats, IComparable> GetStatAccessor(string name);
}