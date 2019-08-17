using NUnit.Framework;

namespace RowSearch.Tests
{
    [TestFixture]
    public class RowItemTests
    {
        [Test]
        [TestCase("sds", false)]
        [TestCase("s", false)]
        [TestCase("31", true)]
        [TestCase("31.43", true)]
        public void IsNumber(string lineItem, bool numberPassed)
        {
            var rowItem = RowItem.Create(lineItem);
            Assert.AreEqual(numberPassed, rowItem.IsNumber);
        }

        [Test]
        [TestCase("sds", null)]
        [TestCase("s", null)]
        [TestCase("31", 31.0f)]
        [TestCase("31.43", 31.43f)]
        public void Value(string lineItem, float? val)
        {
            var rowItem = RowItem.Create(lineItem);
            Assert.AreEqual(rowItem.Value, val);
        }
    }
}