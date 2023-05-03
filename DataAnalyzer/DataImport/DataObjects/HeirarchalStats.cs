using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalyzer.DataImport.DataObjects
{
    internal class HeirarchalStats : Stats, IHeirarchalStats
    {
        public IComparable Key { get; set; }

        public ICollection<IStats> Values { get; set; } = new List<IStats>();

        public ICollection<IHeirarchalStats> Children { get; set; } = new List<IHeirarchalStats>();

        public override IReadOnlyCollection<string> ParameterNames
        {
            get
            {
                if (Values.Count > 0)
                {
                    return Values.ElementAt(0).ParameterNames;
                }

                if (Children.Count > 0)
                {
                    return Children.ElementAt(0).ParameterNames;
                }

                return new List<string>();
            }
        }

        //public override T GetEnumeratedParameters<T>()
        //{
        //    if (Values.Count > 0)
        //    {
        //        return Values.ElementAt(0).GetEnumeratedParameters<T>();
        //    }

        //    if (Children.Count > 0)
        //    {
        //        return Children.ElementAt(0).GetEnumeratedParameters<T>();
        //    }

        //    return default;
        //}
    }
}
