using DataAnalyzer.Common.DataObjects;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataParameters
{
  public abstract class DataParameterCollection<T>
    where T : IStats
  {
    protected ICollection<IDataParameter> parameters = new List<IDataParameter>();

    public DataParameterCollection()
    {
      this.InitializeParameters();
    }

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

    protected abstract void InitializeParameters();
  }
}
