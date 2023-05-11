using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.DataImport.DataObjects;

internal static class ComaprableListExtensions
{
    public static IComparableList<T> ToComparableList<T>(this IEnumerable<T> source)
        where T : IComparable => new ComparableList<T>(source.ToList());
}

internal class ComparableList<T> : List<T>, IComparable, IComparableList<T>
    where T : IComparable
{
    public ComparableList() { }
    public ComparableList(List<T> other) : base(other) { }

    // don't really care, hacking this in for now to get things working
    public int CompareTo(object obj)
    {
        if (obj is ICollection<T> collection)
        {
            foreach (T str in collection)
            {
                if (this.All(x => x.CompareTo(str) != 0))
                {
                    return 1;
                }
            }

            return 0;
        }

        return -1;
    }
}
