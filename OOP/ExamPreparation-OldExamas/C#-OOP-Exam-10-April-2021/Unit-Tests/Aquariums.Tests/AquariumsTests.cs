namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        string fishName = "Nemo";
        string aquariumName = "Tank";
        int capacity = 2;

        Fish fish;
        Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            fish = new Fish(fishName);
            aquarium = new Aquarium(aquariumName, capacity);
        }

        [Test]
        public void Test_Fish_Constructor()
        {
            Assert.AreEqual(fishName, fish.Name);
        }

        [Test]
        public void Test_Aquarium_Constructor()
        {
            Assert.AreEqual(aquariumName, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_Aquarium_Name_ShouldThrowExceptionForNullOrEmty(string name)
        {
            Assert.Throws<ArgumentNullException>(()=>
            {
                aquarium = new Aquarium(name, capacity);
            });
        }

        [Test]
        public void Test_Aquarium_Capacity_ShouldThrowExceptionIfBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                aquarium = new Aquarium(aquariumName, -1);
            });
        }

        [Test]
        public void Test_Aquarium_Count()
        {
            aquarium.Add(fish);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void Test_Aquarium_Add_ShouldThrowExceptionIfAquariumIsFull()
        {
            Fish oneMoreFish = new Fish("Goldy");

            aquarium.Add(oneMoreFish);
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(()=>
            {
                  aquarium.Add(new Fish("Error")); 
            });
        }

        [Test]
        public void Test_Aquarium_Remove()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish("Nemo");

            int expectedCount = 0;
            Assert.AreEqual(expectedCount, aquarium.Count);
        }

        [Test]
        public void Test_Aquarium_Remove_ShouldThrowExceptionIfFishIsNull()
        {
            Assert.Throws < InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Error");
            });
        }

        [Test]
        public void Test_Aquarium_SellFish()
        {
            aquarium.Add(fish);

            Assert.AreEqual(fish, aquarium.SellFish("Nemo"));
        }

        [Test]
        public void Test_Aquarium_SellFish_ShouldThrowExceptionIfFishDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("Error");
            });
        }

        [Test]
        public void Test_Aquarium_Report()
        {
            aquarium.Add(fish);

            string expectedReport = $"Fish available at {aquariumName}: {fishName}";

            Assert.AreEqual(expectedReport, aquarium.Report());
        }


    }
}
