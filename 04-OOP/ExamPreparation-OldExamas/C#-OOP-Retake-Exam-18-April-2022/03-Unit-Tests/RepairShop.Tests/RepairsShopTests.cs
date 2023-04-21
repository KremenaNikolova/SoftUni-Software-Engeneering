using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            Car car;
            string garageName = "Garage";
            int mechanicsAvailable = 2;

            [SetUp]
            public void SetUp()
            {
                car = new Car("SeatIbiza", 5);
            }

            [Test]
            public void Test_GarageConstructor()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);

                Assert.AreEqual(garageName, garage.Name);
                Assert.AreEqual(mechanicsAvailable, garage.MechanicsAvailable);
            }

            [TestCase(null)]
            [TestCase("")]
            public void Test_Garage_ShouldThrowExceptionIfNameIsNullOrEmty(string name)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, mechanicsAvailable);
                });
            }

            [TestCase(0)]
            [TestCase(-1)]
            [TestCase(-1000)]
            public void Test_Garage_ShouldThrowExceptionIfAvailableMechanicsAreZeroOrBelow(int mechanics)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage(garageName, mechanics);
                });
            }

            [Test]
            public void Test_Garage_CarsInGarage()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);
                garage.AddCar(car);

                int expectedCount = 1;

                Assert.AreEqual(expectedCount, garage.CarsInGarage);
            }

            [Test]
            public void Test_Garage_AddCarShouldThrowExceptionIfCountOfCarsIsEqualOfAvailibleMachanics()
            {
                Garage garage = new Garage(garageName, 1);
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(new Car("Error", 3));
                });
            }

            [Test]
            public void Test_Garage_FixCar()
            {
                Garage garage = new Garage(garageName, 1);
                garage.AddCar(car);

                garage.FixCar("SeatIbiza");

                int expectedIssues = 0;

                Assert.AreEqual(expectedIssues, car.NumberOfIssues);
            }

            [Test]
            public void Test_Garage_ShouldThrowExpcetionIfCarIsNull()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("Error");
                });
            }

            [Test]
            public void Test_Garage_RemoveFixedCar()
            {
                Garage garage = new Garage(garageName, 1);
                garage.AddCar(car);

                garage.FixCar("SeatIbiza");

                Assert.AreEqual(1, garage.RemoveFixedCar());
            }

            [Test]
            public void Test_Garage_RemoveFixedCarShouldThrowExcpetionIfCountIsZero()
            {
                Garage garage = new Garage(garageName, 1);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }

            [Test]
            public void Test_Garage_Report()
            {
                Garage garage = new Garage(garageName, mechanicsAvailable);
                garage.AddCar(car);

                string expectedMessage = $"There are 1 which are not fixed: SeatIbiza.";

                Assert.AreEqual(expectedMessage, garage.Report());
            }
        }
    }
}