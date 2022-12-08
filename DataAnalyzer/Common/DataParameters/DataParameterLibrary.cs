using DataAnalyzer.Common.DataParameters.TimeStatParameters;
using DataAnalyzer.Services;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.Common.DataParameters
{
    internal class DataParameterLibrary
    {
        private readonly ICollection<IDataParameterCollection> parameters = new List<IDataParameterCollection>();

        public DataParameterLibrary()
        {
            this.LoadParameters();
        }

        public IDataParameterCollection GetParameters(StatType statType)
        {
            return this.parameters.FirstOrDefault(x => x.StatType == statType);
        }

        private void LoadParameters()
        {
            this.parameters.Clear();
            this.parameters.Add(new QueryableParameters());
        }
    }
}
