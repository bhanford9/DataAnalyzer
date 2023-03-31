using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.DataImport.DataObjects.CsvStats
{
    internal class ComparableList : List<string>, IComparable, IComparableList
    {
        public ComparableList() { }
        public ComparableList(List<string> other) : base(other) { }

        // don't really care, hacking this in for now to get things working
        public int CompareTo(object obj)
        {
            if (obj is ICollection<string> collection)
            {
                foreach (string str in collection)
                {
                    if (!this.Any(x => x.Equals(str)))
                    {
                        return 1;
                    }

                    return 0;
                }
            }

            return -1;
        }
    }
}
