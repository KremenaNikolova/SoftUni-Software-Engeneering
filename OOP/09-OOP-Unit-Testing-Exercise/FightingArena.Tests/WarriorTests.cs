namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        Warrior warrior;

        [Test]
        public void Test_ConstructorShouldAcceptName()
        {
            string nickName = "Aradia";
            warrior = new Warrior(nickName, 350, 1000);

            Assert.AreEqual(nickName, warrior.Name);
        }

        [Test]
        public void Test_ConstructorShouldAcceptDamage()
        {
            int expectedDamage = 350;
            warrior = new Warrior("Aradia", expectedDamage, 1000);

            Assert.AreEqual(expectedDamage, warrior.Damage);
        }

        [Test]
        public void Test_ConstructorShouldAcceptHP() 
        {
            int expectedHP = 1000;
            warrior = new Warrior("Aradia", 350, expectedHP);

            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [TestCase("")]
        [TestCase("     ")]
        [TestCase(null)]
        public void Test_NameShouldThrowExceptionIfItIsNullOrWhiteSpce(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, 350, 1000);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1000)]
        public void Test_DamageShouldThrowExceptionIfIsZeroOrBelow(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Aradia", damage, 1000);
            }, "Damage value should be positive!");
        }

        [TestCase(-1)]
        [TestCase(-1000)]
        public void Test_HpShouldThrowExceptionIfIsBelowZero(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Aradia", 350, hp);
            }, "HP should not be negative!");
        }

        [TestCase (30)]
        [TestCase (29)]
        public void Test_AttackShouldThrowExceptionIfHpIsBelowOrEqualOfMinAttackHp(int hp)
        {
            warrior = new Warrior("Aradia", 350, hp);
            Warrior defender = new Warrior("Petar", 250, 1250);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(30)]
        [TestCase(29)]
        public void Test_AttackShouldThrowExceptionIfDefenerHpIsBelowOrEqualOfMinAttackHp(int hp)
        {
            warrior = new Warrior("Aradia", 350, 1000);
            Warrior defender = new Warrior("Petar", 250, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defender);
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void Test_AttackShouldThrowExceptionIfDefenderIsStronger()
        {
            Warrior attacker = new Warrior("Aradia", 250, 1);
            Warrior defender = new Warrior("Petar", 100, 1250);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            }, "You are trying to attack too strong enemy");
        }

        [Test]
        public void Test_AttackShouldDecreaseDefenderHp()
        {
            Warrior attacker = new Warrior("Aradia", 100, 1000);
            Warrior defender = new Warrior("Petar", 250, 1250);

            int expectedDefenderHP = defender.HP - attacker.Damage;
            int expectedAttackerHP = attacker.HP - defender.Damage;
            attacker.Attack(defender);

            Assert.AreEqual(expectedDefenderHP, defender.HP);
            Assert.AreEqual(expectedAttackerHP, attacker.HP);
        }

        [Test]
        public void Test_AttackShouldReturnZeroHp()
        {
            Warrior attacker = new Warrior("Aradia", 100, 1000);
            Warrior defender = new Warrior("Petar", 250, 99);

            int expectedHP = 0;
            int attackerHP = attacker.HP - defender.Damage;
            attacker.Attack(defender);

            Assert.AreEqual(expectedHP, defender.HP);
            Assert.AreEqual(attackerHP, attacker.HP);
        }


    }
}