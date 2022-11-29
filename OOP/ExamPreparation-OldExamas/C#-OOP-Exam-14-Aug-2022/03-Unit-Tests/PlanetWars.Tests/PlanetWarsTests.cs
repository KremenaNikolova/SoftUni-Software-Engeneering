using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void Test_PlanetConstructor()
            {
                string name = "Earth";
                double budged = 1000;

                Planet planet = new Planet(name, budged);

                Assert.AreEqual(name, planet.Name);
                Assert.AreEqual(budged, planet.Budget);
            }

            [Test]
            public void Test_PlanetName()
            {
                string name = "Earth";

                Planet planet = new Planet(name, 1000);

                Assert.AreEqual(name, planet.Name);
            }


            [TestCase("")]
            [TestCase("      ")]
            [TestCase(null)]
            public void Test_PlaneNameShouldThrowExceptionIfIsNullOrWhitespace(string name)
            {
                Assert.Throws<ArgumentException>(()=>
                {
                    Planet planet = new Planet(name, 1000);
                }, "Invalid planet Name");
            }

            [Test]
            public void Test_PlanetBudget()
            {
                double budged = 1000;

                Planet planet = new Planet("Earth", budged);

                Assert.AreEqual(budged, planet.Budget);
            }


        }
    }
}
