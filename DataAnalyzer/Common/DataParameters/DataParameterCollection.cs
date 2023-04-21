using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataParameters
{
    internal abstract class DataParameterCollection<T> : IDataParameterCollection where T : IStats
    {
        protected ICollection<IDataParameter<T>> parameters = new List<IDataParameter<T>>();

        public abstract StatType StatType { get; }

        public IReadOnlyCollection<IDataParameter<IStats>> GetParameters() =>
            this.parameters.Select(x => x as IDataParameter<IStats>).ToList().AsReadOnly();

        public IReadOnlyCollection<IDataParameter<IStats>> GetGroupableParameters() =>
            this.parameters.Where(x => x.CanGroupBy).Select(x => x as IDataParameter<IStats>).ToList().AsReadOnly();

        public IReadOnlyCollection<string> GetGroupableParameterNames() =>
            this.parameters.Where(x => x.CanGroupBy).Select(x => x.Name).ToList().AsReadOnly();

        public IReadOnlyCollection<IDataParameter<IStats>> GetSortableParameters() =>
            this.parameters.Where(x => x.CanSortBy).Select(x => x as IDataParameter<IStats>).ToList().AsReadOnly();

        public IReadOnlyCollection<string> GetSortableParameterNames() =>
            this.parameters.Where(x => x.CanSortBy).Select(x => x.Name).ToList().AsReadOnly();

        public Func<IStats, IComparable> GetStatAccessor(string name) =>
            (_) => this.parameters.First(x => x.Name.Equals(name)).StatAccessor((T)_);

        internal abstract void AddParameters();
    }
}
