namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;
    using System.Runtime.ConstrainedExecution;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void TestConstructorMakeShouldWork()
        {
            string expectedMake = "do smething";

            Car car = new Car(expectedMake, "Seat", 5.5, 60);

            Assert.AreEqual(expectedMake, car.Make);
        }

        [Test]
        public void TestConstructorModelShouldWork()
        {
            string expectedModel = "Seat";

            Car car = new Car("ibiza", expectedModel, 5.5, 60);

            Assert.AreEqual(expectedModel, car.Model);
        }

        [Test]
        public void TestConstructorFuelConsumptoinShouldWork()
        {
            double expectedFuelConsumption = 5.5;

            Car car = new Car("Seat", "Ibiza", expectedFuelConsumption, 60);

            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
        }

        [Test]
        public void TestConstructorFuelCapacityShouldWork()
        {
            int expectedFuelCapacity = 60;

            Car car = new Car("Seat", "Ibiza", 5.5, expectedFuelCapacity);

            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [TestCase("")]
        [TestCase(null)]
        public void TestMakeCanNotBeNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, "Ibiza", 5.5, 60);
            }, "Make cannot be null or empty!");
        }


        [TestCase("")]
        [TestCase(null)]
        public void TestModelCanNotBeNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Seat", model, 5.5, 60);
            }, "Model cannot be null or empty!");
        }


        [TestCase(0.0)]
        [TestCase(-1.1)]
        public void TestFuelConsumptionCanNotBeZeroOrBellow(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Seat", "Ibiza", fuelConsumption, 60);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-10)]
        [Test]
        public void TestFuelCapacityCanNotBeZeroOrBellow(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Seat", "Ibiza", 5.5, capacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(0.0)]
        [TestCase(-10.0)]
        public void TestRefuelFuelAmountCanNotBeNegative(double amount)
        {
            Car car = new Car("Seat", "Ibiza", 5.5, 60);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(amount);
            }, "Fuel amount cannot be zero or negative!");

        }


        [TestCase(60.1)]
        [TestCase(100.0)]
        public void TestRefuelFuelAmountCanNotBeHigherThanCapcity(double amount)
        {
            Car car = new Car("Seat", "Ibiza", 5.5, 60);
            double expecteAmount = 60;
            car.Refuel(amount);

            Assert.AreEqual(expecteAmount, car.FuelAmount);
        }

        [TestCase(30.1)]
        [TestCase(13.3)]
        public void TestRefuelFuelAmountRefuellingPropertly(double amount)
        {
            Car car = new Car("Seat", "Ibiza", 5.5, 60);
            double expecteAmount = car.FuelAmount + amount ;
            car.Refuel(amount);

            Assert.AreEqual(expecteAmount, car.FuelAmount);
        }

        [Test]
        public void TestDriveDistanceWorkPropertly()
        {
            Car car = new Car("Seat", "Ibiza", 5.5, 60);

            car.Refuel(60);
            double distance = 100;
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            double expectedFuelAmount = car.FuelAmount - fuelNeeded;

            car.Drive(distance);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestDriveDistanceShouldThrowExcpetionIfFuelNeededIsBiggedOfFuelAmount()
        {
            Car car = new Car("Seat", "Ibiza", 5.5, 60);

            car.Refuel(20);
            double distance = 1000;

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            }, "You don't have enough fuel to drive!");

        }


    }
}