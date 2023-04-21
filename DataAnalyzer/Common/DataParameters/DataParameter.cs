using DataAnalyzer.DataImport.DataObjects;
using System;

namespace DataAnalyzer.Common.DataParameters
{
    // TODO --> this structure was originally intended for groupable data and doesn't scale well
    //   need to refactor this to better accommodate more dynamic usages
    internal class DataParameter<T> : IDataParameter<T> where T : IStats
    {
        public DataParameter(Func<T, IComparable> extractor, Func<T, bool> validator)
        {
            this.StatAccessor = stats =>
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

        public Func<T, IComparable> StatAccessor { get; }
    }
}
