using DataAnalyzer.DataImport.DataObjects;
using System;

namespace DataAnalyzer.Common.DataParameters
{
    internal class GroupableStatAccessor<T> : StatAccessor<T>, IGroupableStatAccessor<T>
        where T : IStats
    {
        public GroupableStatAccessor(Func<T, IComparable> extractor, Func<T, bool> validator)
            : base(extractor, validator)
        {
        }

        public bool CanGroupBy { get; set; }
    }
}
