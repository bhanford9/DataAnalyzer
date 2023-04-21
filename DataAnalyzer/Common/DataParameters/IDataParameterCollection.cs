using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Services.Enums;
using System;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataParameters
{
    internal interface IDataParameterCollection
    {
        StatType StatType { get; }

        IReadOnlyCollection<string> GetGroupableParameterNames();
        IReadOnlyCollection<IDataParameter> GetGroupableParameters();
        IReadOnlyCollection<IDataParameter> GetParameters();
        IReadOnlyCollection<string> GetSortableParameterNames();
        IReadOnlyCollection<IDataParameter> GetSortableParameters();
        Func<IStats, IComparable> GetStatAccessor(string name);
    }
}