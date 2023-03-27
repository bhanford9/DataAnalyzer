using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DataAnalyzerTest.Utilities
{
    public static class AssertionExtensions
    {
        public static void CountIs<T>(IEnumerable<T> source, int count)
        {
            Assert.Collection(source, Enumerable.Repeat<Action<T>>(x => { }, count).ToArray());
        }
    }
}
