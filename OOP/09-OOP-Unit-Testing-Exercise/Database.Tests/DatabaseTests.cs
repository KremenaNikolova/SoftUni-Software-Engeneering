namespace Database.Tests
{
    using NUnit.Framework;
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

        public void TestShouldThrowExceptionIfDataCountIs16AndAbove()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(()=>
            {
                Database db = new Database(data);
            }, "Array's capacity must be exactly 16 integers!");

        }
    }
}
