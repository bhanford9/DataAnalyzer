using DataAnalyzer.DataImport.DataObjects;
using System;

namespace DataAnalyzer.Common.DataParameters
{
    internal class StatAccessor<T> : IStatAccessor<T> where T : IStats
    {
        private Func<T, bool> validator;
        private Func<T, IComparable> extractor;

        public StatAccessor(Func<T, IComparable> extractor, Func<T, bool> validator)
        {
            this.extractor = extractor;
            this.validator = validator;
        }

        public string Name { get; set; } = string.Empty;

        public IComparable GetValue(T stats)
        {
            if (validator(stats))
            {
                return extractor(stats);
            }

            throw new Exception("Stats passed in for parameter " + this.Name + " are not valid");
        }
    }
}
