using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestConstructorShouldWorkPropertlyAttackPoints()
        {
            int testAttack = 20;
            int testDurabilityPoints = 100;

            Axe axe = new Axe(testAttack, testDurabilityPoints);

            Assert.AreEqual(testAttack, axe.AttackPoints);
        }
        [Test]
        public void TestConstructorShouldWorkPropertlyDurabilityPoints()
        {
            int testAttack = 20;
            int testDurabilityPoints = 100;

            Axe axe = new Axe(testAttack, testDurabilityPoints);
            Assert.AreEqual(testDurabilityPoints, axe.DurabilityPoints);
        }

        [Test]
        public void TestAttackIsLoosingDurabilityPointsWhenAttack()
        {
            int testAttack = 20;
            int testDurabilityPoints = 100;

            Axe axe = new Axe(testAttack, testDurabilityPoints);

            int expectedDuravility = testDurabilityPoints - 1;
            Dummy dummy = new Dummy(100, 250);
            axe.Attack(dummy);

            Assert.AreEqual(expectedDuravility, axe.DurabilityPoints);
        }

        [Test]
        public void TestAttcksWhenDurabilityPointsAreBelowOrEqualToZeto()
        {
            Axe axe = new Axe(120, 0);
            Dummy dummy = new Dummy(100, 120);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            }, "Axe is broken.");
        }
    }
}