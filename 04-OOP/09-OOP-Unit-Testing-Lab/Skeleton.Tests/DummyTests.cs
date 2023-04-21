using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        //[SetUp]
        //public void SetUp()
        //{
        //    Dummy dummy = new Dummy();
        //}

        [Test]
        public void TestConstructorHealthShouldWorkPropertly()
        {
            int expectedHealth = 100;
            Dummy dummy = new Dummy(expectedHealth, 250);

            Assert.AreEqual(expectedHealth, dummy.Health);
        }

        [Test]
        public void TestTakeAttckShouldDecreaseHealthPropertly()
        {
            int health = 100;
            Dummy dummy = new Dummy(health, 250);

            int attackPoints = 25;
            int expectedHealth = health - attackPoints;
            dummy.TakeAttack(attackPoints);

            Assert.AreEqual(expectedHealth, dummy.Health);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void TestTakeAttackShouldThrowExpeptionWhenDummyIsDied(int health)
        {
            Dummy dummy = new Dummy(health, 250);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(20);
            }, "Dummy is dead.");
        }

        [Test]
        public void TestGiveExpercienceTakeExperciencePropertlyWhenTargetIsDied()
        {
            int expectedExperience = 250;

            Dummy dummy = new Dummy(0, expectedExperience);
            dummy.GiveExperience();

            Assert.AreEqual(expectedExperience, dummy.GiveExperience());

        }

        [Test]
        public void TestGiveExperienceThrowExpeptionIfTargetIsAlive()
        {
            Dummy dummy = new Dummy(100, 250);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            }, "Target is not dead.");

        }

        [TestCase(0)]
        [TestCase(-10)]
        public void TestIsDeadMethodGivesTrueRithfully(int health)
        {
            Dummy dummy = new Dummy(health, 250);

            dummy.IsDead();

            Assert.IsTrue(dummy.IsDead());
        }

        [TestCase(1)]
        [TestCase(100)]
        public void TestIsDeadMethodGivesFalseRithfully(int health)
        {
            Dummy dummy = new Dummy(health, 250);

            dummy.IsDead();

            Assert.IsFalse(dummy.IsDead());
        }


    }
}