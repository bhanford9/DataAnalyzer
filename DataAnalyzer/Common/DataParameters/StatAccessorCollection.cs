using DataAnalyzer.DataImport.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataParameters;

// this class acts as a polymorphic way of getting data from any given IStats based on a string
internal abstract class StatAccessorCollection<T> : IStatAccessorCollection where T : IStats
{
    protected ICollection<IStatAccessor<T>> statAccessors = new List<IStatAccessor<T>>();

    public IReadOnlyCollection<IStatAccessor<IStats>> GetStatAccessors() =>
        this.statAccessors.OfType<IStatAccessor<IStats>>().ToList().AsReadOnly();

    public Func<IStats, IComparable> GetStatAccessor(string name) =>
        (_) => this.statAccessors.First(x => x.Name.Equals(name)).GetValue((T)_);

    public IComparable GetData(string name, T stats) =>
        this.statAccessors.First(x => x.Name.Equals(name)).GetValue(stats);

    internal abstract void AddStatAccessor();
}
