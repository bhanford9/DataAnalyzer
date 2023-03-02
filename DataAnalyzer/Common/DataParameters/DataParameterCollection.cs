using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataParameters
{
    internal abstract class DataParameterCollection : IDataParameterCollection
    {
        protected ICollection<IDataParameter> parameters = new List<IDataParameter>();

        public DataParameterCollection()
        {
            this.InitializeParameters();
        }

        public abstract StatType StatType { get; }

        public ICollection<IDataParameter> GetParameters() => this.parameters;

        public ICollection<IDataParameter> GetGroupableParameters() => this.parameters.Where(x => x.CanGroupBy).ToList();

        public ICollection<string> GetGroupableParameterNames() => this.parameters.Where(x => x.CanGroupBy).Select(x => x.Name).ToList();

        public ICollection<IDataParameter> GetSortableParameters() => this.parameters.Where(x => x.CanSortBy).ToList();

        public ICollection<string> GetSortableParameterNames() => this.parameters.Where(x => x.CanSortBy).Select(x => x.Name).ToList();

        public Func<IStats, IComparable> GetStatAccessor(string name) => this.parameters.First(x => x.Name.Equals(name)).StatAccessor;

        protected abstract void InitializeParameters();
    }
}
