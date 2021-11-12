using DataAnalyzer.Common.DataConfigurations;
using DataAnalyzer.Common.DataObjects;
using System.Collections.Generic;

namespace DataAnalyzer.Common.DataOrganizers
{
  public interface IDataOrganizer
  {
    public HeirarchalStats Organize(IDataConfiguration configuration, ICollection<IStats> data);
  }
}
