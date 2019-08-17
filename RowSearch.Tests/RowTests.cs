using NUnit.Framework;

namespace RowSearch.Tests
{
    [TestFixture]
    public class RowTests
    {
        [Test]
        [TestCase("4,3.0,5,3", true)]
        [TestCase("4,a,5,3", false)]
        [TestCase("4,3.0,5fd,3", false)]
        public void IsValid(string rowText, bool isValid)
        {
            var row = Row.Create(rowText);
            Assert.AreEqual(isValid, row.IsValid);
        }
    }
}