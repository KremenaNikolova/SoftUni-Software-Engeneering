using NUnit.Framework;
using System;
using System.ComponentModel;
using System.Xml.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;
            [SetUp]
            public void SetUp()
            {
                planet = new Planet("Mars", 1250);
            }

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
            [TestCase(null)]
            public void Test_PlaneNameShouldThrowExceptionIfIsNullOrWhitespace(string name)
            {
                Assert.Throws<ArgumentException>(() =>
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

            [TestCase(-1)]
            [TestCase(-1000)]
            public void Test_PlanetBudgedShouldThrowExceptionIfIsBelowZero(double budged)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Earth", budged);
                }, "Budget cannot drop below Zero!");
            }

            [Test]
            public void Test_IReadOnlyCollectionShouldAcceptNewWeapons()
            {
                Weapon weapon = new Weapon("NurclearWeapon", 500, 50);
                planet.AddWeapon(weapon);

                int excpectedCount = 1;

                Assert.AreEqual(excpectedCount, planet.Weapons.Count);
            }

            [Test]
            public void Test_PlanetMilitaryPowerRatio()
            {
                Weapon weapon = new Weapon("NurclearWeapon", 500, 50);
                planet.AddWeapon(weapon);

                double expectedMilitaryPowerRatio = 50;

                Assert.AreEqual(expectedMilitaryPowerRatio, planet.MilitaryPowerRatio);
            }

            [Test]
            public void Test_PlanetProfit()
            {
                planet.Profit(500);
                double expectedBudged = 1750;

                Assert.AreEqual(expectedBudged, planet.Budget);
            }

            [Test]
            public void Test_PlanetSpendFunds()
            {
                planet.SpendFunds(250);
                double expectedBudged = 1000;

                Assert.AreEqual(expectedBudged, planet.Budget);
            }

            [TestCase(1500)]
            [TestCase(1251)]
            public void Test_PlanetSpendFundsShouldThrowExceptionIfAmountIsBiggerOfBudged(double amount)
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(amount);
                }, "Not enough funds to finalize the deal.");
            }

            [Test]
            public void Test_PlanetAddWeapon()
            {
                Weapon weapon = new Weapon("NurclearWeapon", 500, 50);
                planet.AddWeapon(weapon);

                int expectedWeaponCount = 1;

                Assert.AreEqual(expectedWeaponCount, planet.Weapons.Count);
            }

            [Test]
            public void TestPlanetAddWeaponShouldThrowExceptionIfWeaponAlreadyIsAdded()
            {
                Weapon weapon = new Weapon("NurclearWeapon", 500, 50);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                }, $"There is already a {weapon.Name} weapon.");
            }

            [Test]
            public void Test_RemoveWeapon()
            {
                Weapon weapon = new Weapon("NurclearWeapon", 500, 50);
                planet.AddWeapon(weapon);

                planet.RemoveWeapon(weapon.Name);

                int expectedWeaponCount = 0;

                Assert.AreEqual(expectedWeaponCount, planet.Weapons.Count);

            }

            [Test]
            public void Test_PlanetUpgradeWeapon()
            {
                Weapon weapon = new Weapon("NurclearWeapon", 500, 50);
                planet.AddWeapon(weapon);

                planet.UpgradeWeapon(weapon.Name);

                int expectedDecstructionLevel = 51;
                Assert.AreEqual(expectedDecstructionLevel, weapon.DestructionLevel);
            }

            [Test]
            public void Test_PlanetUpgradeWeaponShouldThrowExceptionIfThisWeaponDoesntExist()
            {
                string weaponName = "Error";
                Assert.Throws<InvalidOperationException>(()=>
                {
                    planet.UpgradeWeapon(weaponName);
                }, $"{weaponName} does not exist in the weapon repository of {planet.Name}");
            }

            [Test]
            public void Test_PlanetDestructOpponen()
            {
                Planet attacker = new Planet("Earth", 1250);
                Planet defender = new Planet("Mars", 1500);

                Weapon weaponAttacker = new Weapon("NurclearWeapon", 500, 50);
                Weapon weaponDefender = new Weapon("DrugoNeshto", 500, 25);
                attacker.AddWeapon(weaponAttacker);
                defender.AddWeapon(weaponDefender);

                attacker.DestructOpponent(defender);

                string expectedMessage = $"{defender.Name} is destructed!";

                Assert.AreEqual(expectedMessage, attacker.DestructOpponent(defender));
            }

            [Test]
            public void Test_PlanetDestructOpponenShouldThrowExceptionIfMilitaryPointsAreEqual()
            {
                Planet attacker = new Planet("Earth", 1250);
                Planet defender = new Planet("Mars", 1500);

                Weapon weaponAttacker = new Weapon("NurclearWeapon", 500, 50);
                Weapon weaponDefender = new Weapon("DrugoNeshto", 500, 50);
                attacker.AddWeapon(weaponAttacker);
                defender.AddWeapon(weaponDefender);

                Assert.Throws<InvalidOperationException>(()=>
                {
                    attacker.DestructOpponent(defender);
                }, $"{defender.Name} is too strong to declare war to!");

            }

            [Test]
            public void Test_PlanetDestructOpponenShouldThrowExceptionIfMilitaryPointsOfDefenderAreBigger()
            {
                Planet attacker = new Planet("Earth", 1250);
                Planet defender = new Planet("Mars", 1500);

                Weapon weaponAttacker = new Weapon("NurclearWeapon", 500, 50);
                Weapon weaponDefender = new Weapon("DrugoNeshto", 500, 55);
                attacker.AddWeapon(weaponAttacker);
                defender.AddWeapon(weaponDefender);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    attacker.DestructOpponent(defender);
                }, $"{defender.Name} is too strong to declare war to!");

            }

            [Test]
            public void Test_WeaponConstructor()
            {
                string name = "NuclearWeapon";
                double price = 500;
                int destructionLevel = 50;

                Weapon wep = new Weapon(name, price, destructionLevel);

                Assert.AreEqual(name, wep.Name );
                Assert.AreEqual(price, wep.Price );
                Assert.AreEqual(destructionLevel, wep.DestructionLevel );

            }

            [Test]
            public void Test_WeaponName()
            {
                string name = "Pesho";
                Weapon weaponAttacker = new Weapon(name, 500, 50);

                Assert.AreEqual(name, weaponAttacker.Name );
            }

            [Test]
            public void Test_WeaponPrice()
            {
                double price = 500;
                Weapon wep = new Weapon("Pesho", price, 50);

                Assert.AreEqual(price, wep.Price );
            }


            [Test]  
            public void Test_WeaponShouldThrowExceptionIfPriceIsBelowZero()
            {
                double price = -1;

                Assert.Throws<ArgumentException>(() => 
                {
                    Weapon wep = new Weapon("Pesho", price, 50);
                }, "Price cannot be negative.");
            }

            [Test]
            public void Test_WeapongDestructionLevel()
            {
                int destructionLevel = 50;

                Weapon wep = new Weapon("Pesho", 500, destructionLevel);

                Assert.AreEqual(destructionLevel, wep.DestructionLevel);
            }

            [Test]
            public void Test_WeaponIncreaseDurationLevel()
            {
                Weapon wep = new Weapon("Pesho", 500, 50);
                wep.IncreaseDestructionLevel();

                int expectedDestructionLevel = 51;

                Assert.AreEqual(expectedDestructionLevel, wep.DestructionLevel);
            }

            [Test]
            public void Test_IsNuclearShuldReturnTrue()
            {
                int destructionLevel = 10;
                Weapon wep = new Weapon("Pesho", 500, destructionLevel);

                Assert.IsTrue(wep.IsNuclear);
            }

            [Test]
            public void Test_IsNuclearShuldReturnFalse()
            {
                int destructionLevel = 5;
                Weapon wep = new Weapon("Pesho", 500, destructionLevel);

                Assert.IsFalse(wep.IsNuclear);
            }
        }

    }
}
