using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzer.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataParameters
{
    internal abstract class DataParameterCollection : IDataParameterCollection
    {
        protected ICollection<IDataParameter> parameters = new List<IDataParameter>();

        public abstract StatType StatType { get; }

        public IReadOnlyCollection<IDataParameter> GetParameters() => this.parameters.ToList().AsReadOnly();

        public IReadOnlyCollection<IDataParameter> GetGroupableParameters() => this.parameters.Where(x => x.CanGroupBy).ToList().AsReadOnly();

        public IReadOnlyCollection<string> GetGroupableParameterNames() => this.parameters.Where(x => x.CanGroupBy).Select(x => x.Name).ToList().AsReadOnly();

        public IReadOnlyCollection<IDataParameter> GetSortableParameters() => this.parameters.Where(x => x.CanSortBy).ToList().AsReadOnly();

        public IReadOnlyCollection<string> GetSortableParameterNames() => this.parameters.Where(x => x.CanSortBy).Select(x => x.Name).ToList().AsReadOnly();

        public Func<IStats, IComparable> GetStatAccessor(string name) => this.parameters.First(x => x.Name.Equals(name)).StatAccessor;

        internal abstract void AddParameters();
    }
}
