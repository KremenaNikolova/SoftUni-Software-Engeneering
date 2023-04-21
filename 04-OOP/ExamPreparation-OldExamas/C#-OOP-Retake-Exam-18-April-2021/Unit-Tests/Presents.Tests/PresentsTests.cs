namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        string presentName = "Present";
        double magic = 120;

        Present present;
        Bag bag;

        [SetUp]
        public void SetUp()
        {
            present = new Present(presentName, magic);
            bag = new Bag();
        }

        [Test]
        public void Test_Present_Constructor()
        {
            Assert.AreEqual(presentName, present.Name);
            Assert.AreEqual(magic, present.Magic);
        }

        [Test]
        public void Test_Bag_Create()
        {
            string expectingMessage = $"Successfully added present {present.Name}.";

            Assert.AreEqual(expectingMessage, bag.Create(present));
        }

        [Test]
        public void Test_Bag_Create_ShouldThrowExceptionIfPresentIsNull()
        {
            Present present = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void Test_Bag_Create_ShouldThrowExceptionIfPresentAlreadyExist()
        {
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void Test_Bag_Remoce()
        {
            bag.Create(present);

            Assert.IsTrue(bag.Remove(present));
        }

        [Test]
        public void Test_Bag_GetPresentWithLeastMagic()
        {
            Present oneMorePresent = new Present("Test", 150);

            bag.Create(present);
            bag.Create(oneMorePresent);

            Assert.AreEqual(present, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void Test_Bag_GetPresent()
        {
            bag.Create(present);

            Assert.AreEqual(present, bag.GetPresent(presentName));
        }

        [Test]
        public void Test_Bag_GetPresentsCollection()
        {
            List<Present> presents = new List<Present>();
            presents.Add(present);
            bag.Create(present);

            Assert.AreEqual(presents, bag.GetPresents());
        }

    }
}
