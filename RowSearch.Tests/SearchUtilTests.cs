using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace RowSearch.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(new[]
        {
            "4,3.0,5,3",
            "6,m,a,4,15.4",
            "21.3,5,1,a",
            "14.54,43.33,43,11"
        }, 4)]
        [TestCase(new[]
        {
            "4,f,5,3",
            "6,m,a,4,15.4",
            "21.3,5,1,a",
            "14.54,a,43,11"
        }, null)]
        public void MaxSumRowNumber(string[] lines, int? maxSumRowNumber)
        {
            var util = new SearchUtil(lines);
            Assert.AreEqual(maxSumRowNumber, util.MaxSumRowNumber);
        }

        [Test]
        [TestCase(new[]
        {
            "4,3.0,5,3",
            "6,m,a,4,15.4",
            "21.3,5,1,a",
            "14.54,43.33,43,11"
        }, new[] {2, 3})]
        [TestCase(new[]
        {
            "4,5,5,3",
            "6,4,5,4,15.4",
            "21.3,5,1,4",
            "14.54,2,43,11"
        }, new int[0])]
        [TestCase(new[]
        {
            "4,5,5,a",
            "21.3,5,1,5",
            "14.54,2,43,11"
        }, new[] {1})]
        public void NotValidRowsNumbers(string[] lines, int[] notValidRowNumbers)
        {
            var util = new SearchUtil(lines);
            CollectionAssert.AreEqual(notValidRowNumbers, util.NotValidRowsNumbers.ToArray());
        }
    }
}