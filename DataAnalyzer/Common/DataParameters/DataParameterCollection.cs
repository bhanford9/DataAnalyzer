using DataAnalyzer.Common.DataObjects;
using DataAnalyzer.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataParameters
{
  public abstract class DataParameterCollection : IDataParameterCollection
  {
    protected ICollection<IDataParameter> parameters = new List<IDataParameter>();

    public DataParameterCollection()
    {
      this.InitializeParameters();
    }

    public abstract StatType StatType { get; }

    public ICollection<IDataParameter> GetParameters()
    {
      return this.parameters;
    }

    public ICollection<IDataParameter> GetGroupableParameters()
    {
      return this.parameters.Where(x => x.CanGroupBy).ToList();
    }

    public ICollection<string> GetGroupableParameterNames()
    {
      return this.parameters.Where(x => x.CanGroupBy).Select(x => x.Name).ToList();
    }

    public ICollection<IDataParameter> GetSortableParameters()
    {
      return this.parameters.Where(x => x.CanSortBy).ToList();
    }

    public ICollection<string> GetSortableParameterNames()
    {
      return this.parameters.Where(x => x.CanSortBy).Select(x => x.Name).ToList();
    }

    public Func<IStats, IComparable> GetStatAccessor(string name)
    {
      return this.parameters.First(x => x.Name.Equals(name)).StatAccessor;
    }

    protected abstract void InitializeParameters();
  }
}
