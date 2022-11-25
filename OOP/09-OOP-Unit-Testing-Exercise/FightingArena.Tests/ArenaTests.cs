namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warr;
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warr = new Warrior("Aradia", 350, 350);
        }

        [Test]
        public void Test_ArenaConstructor()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena);
        }

        [Test]
        public void Test_ArenaCollection()
        {
            Warrior warrior1 = new Warrior("Kremena", 250, 205);
            Warrior warrior2 = new Warrior("Petar", 320, 1000);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            List<Warrior> warriors = new List<Warrior>() { warrior1, warrior2 };

            Assert.AreEqual(warriors, arena.Warriors);
        }

        [Test]
        public void Test_EnrollMethodShouldAddWarriorToArenaList()
        {
            arena.Enroll(warr);

            int expectedCount = 1;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void Test_EnrollShouldThrowExceptionIfWarriorIsAlreadyAdded()
        {
            arena.Enroll(warr);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warr);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void Test_FightShouldAttackDefender()
        {
            Warrior attacker = warr;
            Warrior defender = new Warrior("Petar", 100, 1100);
            int expectedDefenderHeath = defender.HP - attacker.Damage;
            int expectedAttackerHealth = attacker.HP - defender.Damage;
            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("Aradia", "Petar");

            Assert.AreEqual(expectedDefenderHeath, defender.HP);
            Assert.AreEqual(expectedAttackerHealth, attacker.HP);
        }

        [Test]
        public void Test_FightShouldThrowExceptionIfAttakerIsNull()
        {
            Warrior attacker = warr;
            Warrior defender = new Warrior("Petar", 100, 1100);
            int expectedDefenderHeath = defender.HP - attacker.Damage;
            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Stefan", "Petar");
            }, $"There is no fighter with name Stefan enrolled for the fights!");
        }

        [Test]
        public void Test_FightShouldThrowExceptionIfDefenderIsNull()
        {
            Warrior attacker = warr;
            Warrior defender = new Warrior("Petar", 100, 1100);
            int expectedDefenderHeath = defender.HP - attacker.Damage;
            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Aradia", "Stefan");
            }, $"There is no fighter with name Stefan enrolled for the fights!");
        }


    }
}
