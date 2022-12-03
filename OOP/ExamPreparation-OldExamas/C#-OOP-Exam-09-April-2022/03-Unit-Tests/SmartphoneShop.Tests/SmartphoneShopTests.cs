using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        string modelName = "Samsung";
        int maximumBaterryCharge = 100;

        private Shop shop;
        int capacity = 10;

        [SetUp]
        public void SetUp()
        {
            smartphone = new Smartphone(modelName, maximumBaterryCharge);
            shop = new Shop(capacity);
        }

        [Test]
        public void Test_Phone_Constructor()
        {
            smartphone = new Smartphone(modelName, maximumBaterryCharge);
            int currBaterryCharged = 100;

            Assert.AreEqual(modelName, smartphone.ModelName);
            Assert.AreEqual(maximumBaterryCharge, smartphone.MaximumBatteryCharge);
            Assert.AreEqual(currBaterryCharged, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_Shop_Constructor()
        {
            shop = new Shop(capacity);
            shop.Add(smartphone);

            Assert.AreEqual(capacity, shop.Capacity);
            Assert.AreEqual(1, shop.Count);

        }

        [Test]
        public void Test_Shop_Capacity()
        {
            shop = new Shop(capacity);
            int expectedCapacity = 10;

            Assert.AreEqual(expectedCapacity, shop.Capacity);
        }

        [Test]
        public void Test_Shop_ShouldThrowExceptionIfCapacityIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                shop = new Shop(-1);
            });
        }

        [Test]
        public void Test_Shop_Count()
        {
            shop.Add(smartphone);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, shop.Count);
        }

        [Test]
        public void Test_Shop_AddShouldThrowExceptionIfModelAlreadyExist()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone);
            });
        }

        [Test]
        public void Test_Shop_AddIsMaxCapacityShouldThrowException ()
        {
            for (int i = 0; i < 10; i++)
            {
                shop.Add(new Smartphone(i.ToString(), 100));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone);
            });
        }

        [Test]
        public void Test_Shop_Remove()
        {
            shop.Add(smartphone);
            shop.Remove("Samsung");

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, shop.Count);
        }

        [Test]
        public void Test_Shop_RemoveShouldThrowExceptionIfPhoneModelDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Error");
            });
        }

        [Test]
        public void Test_Shop_TestPhone()
        {
            string phoneModel = "Samsung";
            int batteryUsage = 55;

            shop.Add(smartphone);
            shop.TestPhone(phoneModel, batteryUsage);

            int expctedBatteryLeft = 100 - batteryUsage;

            Assert.AreEqual(expctedBatteryLeft, smartphone.CurrentBateryCharge);

        }

        [Test]
        public void Test_Shop_TestPhoneShouldThrowExceptionIfPhoneDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(modelName, 55);
            });
        }

        [Test]
        public void Test_Shop_TestPhoneShouldThrowExceptionIfPhoneNameIsNull()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Error", 55);
            });
        }

        [Test]
        public void Test_Shop_TestPhoneShouldThrowExceptionIfBatteryChargeIsLowerOfBatteryUsage()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(modelName, 101);
            });
        }

        [Test]
        public void Test_Shop_ChargePhone()
        {
            shop.Add(smartphone);
            shop.TestPhone(modelName, 55);

            shop.ChargePhone(modelName);

            Assert.AreEqual(smartphone.MaximumBatteryCharge, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_Shop_ChargePhoneShoulThrowExceptionIfPhoneDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Error");
            });
        }
    }

    
}