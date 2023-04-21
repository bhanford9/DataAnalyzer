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
        IReadOnlyCollection<IDataParameter<IStats>> GetGroupableParameters();
        IReadOnlyCollection<IDataParameter<IStats>> GetParameters();
        IReadOnlyCollection<string> GetSortableParameterNames();
        IReadOnlyCollection<IDataParameter<IStats>> GetSortableParameters();
        Func<IStats, IComparable> GetStatAccessor(string name);
    }
}