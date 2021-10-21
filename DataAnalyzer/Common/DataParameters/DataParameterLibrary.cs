using DataAnalyzer.Common.DataParameters.TimeStatParameters;
using DataAnalyzer.Services;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataParameters
{
  public class DataParameterLibrary
  {
    private readonly ICollection<IDataParameterCollection> parameters = new List<IDataParameterCollection>();

    public DataParameterLibrary()
    {
      this.LoadParameters();
    }

    public IDataParameterCollection GetParameters(StatType statType)
    {
      return this.parameters.First(x => x.StatType == statType);
    }

    private void LoadParameters()
    {
      this.parameters.Clear();
      this.parameters.Add(new QueryableParameters());
    }
  }
}
