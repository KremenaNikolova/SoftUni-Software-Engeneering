namespace Database.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void TestConstructorDataShouldWorkPropertly()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Database db = new Database(data);

            int expextedData = data.Length;
            int actualData = db.Count;

            Assert.AreEqual(expextedData, actualData);
        }

        [Test]
        public void TestShouldThrowExceptionIfDataCountIs16AndAbove()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                Database db = new Database(data);
            }, "Array's capacity must be exactly 16 integers!");

        }

        [Test]
        public void TestRemoveShouldRemoveItemsPropetly()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            Database db = new Database(data);

            db.Remove();
            db.Remove();
            int exectedDataCount = data.Length - 2;
            int actualDataCount = db.Count;

            Assert.AreEqual(exectedDataCount, actualDataCount);
        }

        [Test]
        public void TestRemoveShouldThrowExceptionIfCountIsZeroOrBelow()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            }, "The collection is empty!");
        }
    }
}
