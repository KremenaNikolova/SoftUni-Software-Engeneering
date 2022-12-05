using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gyms.Tests
{
    public class GymsTests
    {
         string name = "DragonBall";
         int capacity = 2;
         Gym gym;

        [SetUp]
        public void SetUp()
        {
            gym = new Gym(name, capacity);
        }

        [Test]
        public void Test_Athlete_Constructor()
        {
            Athlete athlete = new Athlete("Angelin");

            Assert.AreEqual("Angelin", athlete.FullName);
            Assert.IsFalse(athlete.IsInjured);
        }

        [Test]
        public void Test_Gym_Constructor()
        {
            gym= new Gym(name, capacity);

            Assert.AreEqual(name, gym.Name);
            Assert.AreEqual(capacity, gym.Capacity);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_Gym_ShouldThrowExceptionIfNameIsEmtyOrNull(string gymName)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                gym = new Gym(gymName, capacity);
            });
        }

        [Test]
        public void Test_Gym_ShouldThrowExceptionIfCapacityIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                gym = new Gym(name, -1);
            });
        }

        [Test]
        public void Test_Gym_AddAthletes()
        {
            Athlete athlete = new Athlete("Heastia");
            gym.AddAthlete(athlete);

            int expectedCount = 1;
            Assert.AreEqual(expectedCount, gym.Count);
        }

        [Test]
        public void Test_Gym_AddAthletes_ShouldThrowExceptionIfTheCapacityIsFull()
        {
            Athlete firstAthlete = new Athlete("Heastia");
            Athlete secondAthlete = new Athlete("Petar");

            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(new Athlete("Error"));
            });
        }

        [Test]
        public void Test_Gym_RemoveAthlete()
        {
            Athlete athlete = new Athlete("Heastia");
            gym.AddAthlete(athlete);

            string athleteName = "Heastia";
            gym.RemoveAthlete(athleteName);

            int expectedCount = 0;
            Assert.AreEqual(expectedCount, gym.Count);
        }

        [Test]
        public void Test_Gym_RemoveAthlete_ShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Error");
            });
        }

        [Test]
        public void Test_Gym_InjureAthlete()
        {
            Athlete athlete = new Athlete("Heastia");
            gym.AddAthlete(athlete);

            gym.InjureAthlete("Heastia");

            Assert.AreEqual(true, athlete.IsInjured);
            Assert.AreEqual("Heastia", athlete.FullName);
        }

        [Test]
        public void Test_Gym_InjureAthlete_ShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Error");
            });
        }

        [Test]
        public void Test_Gym_Report()
        {
            Athlete firstAthlete = new Athlete("Heastia");
            Athlete secondAthlete = new Athlete("Petar");
            List<Athlete> athletes= new List<Athlete>() { firstAthlete,secondAthlete};

            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);

            gym.InjureAthlete("Heastia");

            string expectedString = $"Active athletes at {gym.Name}: {string.Join(", ", athletes.Where(x => !x.IsInjured).Select(f => f.FullName))}";

            Assert.AreEqual(expectedString, gym.Report());

        }
    }
}
