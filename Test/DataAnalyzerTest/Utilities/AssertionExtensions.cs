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

        public static void SequenceEqual<T>(
            IEnumerable<T> expected,
            IEnumerable<T> actual,
            Func<T, T, bool> equal)
        {
            var expectedList = expected.ToList();
            var actualList = actual.ToList();

            CountIs(actualList, expectedList.Count);

            for (int i = 0; i < expectedList.Count(); i++)
            {
                Assert.True(equal(expectedList[i], actualList[i]));
            }
        }
    }
}
