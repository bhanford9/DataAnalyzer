using DataAnalyzer.Common.DataObjects;
using System;

namespace DataAnalyzer.Common.DataParameters
{
    internal class DataParameter : IDataParameter
    {
        public DataParameter(Func<IStats, IComparable> extractor, Func<IStats, bool> validator)
        {
            this.StatAccessor = (stats) =>
            {
                if (validator(stats))
                {
                    return extractor(stats);
                }

                throw new Exception("Stats passed in for parameter " + this.Name + " are not valid");
            };
        }

        public string Name { get; set; } = string.Empty;

        public bool CanGroupBy { get; set; } = true;

        public bool CanSortBy { get; set; } = true;

        public Func<IStats, IComparable> StatAccessor { get; }
    }
}
