using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void WeaponConstructorShouldInitializeProperly()
            {
                string weaponeName = "pushka";
                double weaponPrice = 2.5;
                int weapongDestructionLevel = 1;

                Weapon weapon = new Weapon(weaponeName, weaponPrice, weapongDestructionLevel);

                Assert.AreEqual(weaponeName, weapon.Name);
                Assert.AreEqual(weaponPrice, weapon.Price);
                Assert.AreEqual(weapongDestructionLevel, weapon.DestructionLevel);
            }

            [TestCase(-0.1)]
            [TestCase(-1)]
            [TestCase(-10)]
            [TestCase(-1000)]
            public void WeaponPriceShouldThrowExceptionWhenBelowZero(double price)
            {


                Assert.Throws<ArgumentException>((() =>
                {
                    Weapon weapon = new Weapon("pistolet", price, 1);
                }));
            }

            [Test]
            public void WeaponIncreaseDestructionLevelShouldIncrementDestructionLevelBy1()
            {
                Weapon weapon = new Weapon("kalashnik", 2.5, 1);


                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(2, weapon.DestructionLevel);
            }

            [TestCase(10)]
            [TestCase(25)]
            public void WeaponIsNuclearWhenDestructionLevelIs10OrHigher(int destructionLevel)
            {
                Weapon weapon = new Weapon("m4a1", 12.3, destructionLevel);

                Assert.IsTrue(weapon.IsNuclear);
            }

            [TestCase(9)]
            [TestCase(1)]
            [TestCase(0)]
            public void WeaponIsNotNuclearWhenDestructionLevelBelow10(int destructionLevel)
            {
                Weapon weapon = new Weapon("m4a1", 12.3, destructionLevel);

                Assert.IsFalse(weapon.IsNuclear);
            }

            [Test]
            public void PlanetConstructorShouldInitializeProperly()
            {
                string planetName = "Zemq";
                double budget = 12.5;

                Planet planet = new Planet(planetName, budget);

                Assert.AreEqual(planetName, planet.Name);
                Assert.AreEqual(budget, planet.Budget);
            }

            [TestCase(null)]
            [TestCase("")]
            public void PlanetNameCannotBeNullOrEmpty(string planetName)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(planetName, 12.5);
                });
            }

            [TestCase(-0.1)]
            [TestCase(-1)]
            [TestCase(-10)]
            [TestCase(-10000)]
            public void PlanetBudgetCannotBeBelowZero(double budget)
            {
                Assert.Throws<ArgumentException>((() =>
                {
                    Planet planet = new Planet("Mars", budget);
                }));
            }

            [Test]
            public void PlanetWeaponsShouldReturnListOfWeapons()
            {
                Planet planet = new Planet("pluton", 15.6);

                Assert.AreEqual(new List<Weapon>(), planet.Weapons);
            }

            [Test]
            public void PlanetMilitaryPowerRatioShouldReturnSumOfAllWeapons()
            {
                int w1DestructLevel = 1;
                int w2DestructLevel = 3;
                int w3DestructLevel = 5;

                double expectedMilitaryRatio = w1DestructLevel + w2DestructLevel + w3DestructLevel;

                Weapon weapon1 = new Weapon("pushka", 12, w1DestructLevel);
                Weapon weapon2 = new Weapon("kalashnik", 12, w2DestructLevel);
                Weapon weapon3 = new Weapon("pistolet", 12, w3DestructLevel);

                Planet planet = new Planet("mars", 120312);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                Assert.AreEqual(expectedMilitaryRatio, planet.MilitaryPowerRatio);
            }

            [TestCase(10.5)]
            [TestCase(120)]
            [TestCase(0)]
            public void PlanetProfitShouldIncreaseBudgetByGivenAmount(double budget)
            {
                Planet planet = new Planet("venera", 1);

                double expectedBudget = planet.Budget + budget;

                planet.Profit(budget);

                Assert.AreEqual(expectedBudget, planet.Budget);
            }

            [TestCase(12.6)]
            [TestCase(15)]
            [TestCase(21321)]
            public void PlanetSpendFundsShouldThrowExceptionIfAmountHigherThanBudget(double amountToSpend)
            {
                Planet planet = new Planet("zemq", 12.5);

                Assert.Throws<InvalidOperationException>((() =>
                {
                    planet.SpendFunds(amountToSpend);
                }));
            }

            [TestCase(99.9)]
            [TestCase(50)]
            [TestCase(12.5)]
            public void PlanetSpendFundsShouldDecreaseBudgetByGivenAmount(double amountToSpend)
            {
                Planet planet = new Planet("Mars", 100);

                double expectedBudget = planet.Budget - amountToSpend;

                planet.SpendFunds(amountToSpend);

                Assert.AreEqual(expectedBudget, planet.Budget);
            }

            [Test]
            public void PlanetAddWeaponShouldThrowExceptionWhenWeaponAlreadyAdded()
            {
                Weapon weapon = new Weapon("pistolet", 12.5, 1);

                Planet planet = new Planet("Zemq", 100);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>((() =>
                {
                    planet.AddWeapon(weapon);
                }));
            }

            [Test]
            public void PlanetAddWeaponShouldAddWeaponToCollection()
            {
                Weapon weapon = new Weapon("pistolet", 12.5, 1);

                Planet planet = new Planet("Zemq", 100);

                planet.AddWeapon(weapon);

                Assert.That(planet.Weapons.Contains(weapon));
            }

            [Test]
            public void PlanetAddWeaponShouldIncreaseCollectionCount()
            {
                Weapon weapon = new Weapon("pistolet", 12.5, 2);
                Weapon weapon1 = new Weapon("pushka", 12.5, 2);
                Weapon weapon2 = new Weapon("avtomat", 12.5, 2);

                Planet planet = new Planet("zemq", 100);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(3, planet.Weapons.Count);
            }

            [Test]
            public void PlanetRemoveWeaponShouldRemoveWeaponFromCollection()
            {
                Weapon weapon = new Weapon("pistolet", 12.5, 2);
                Planet planet = new Planet("zemq", 100);

                planet.AddWeapon(weapon);

                planet.RemoveWeapon(weapon.Name);

                Assert.That(!planet.Weapons.Contains(weapon));
            }

            [Test]
            public void PlanetUpgradeWeaponShouldThrowExceptionWhenWeaponDoesNotExistInTheRepository()
            {
                string nonExistingWeaponName = "orajie";
                Weapon weapon = new Weapon("pushka", 12.5, 2);

                Planet planet = new Planet("zemq", 100);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon(nonExistingWeaponName));
            }

            [Test]
            public void PlanetUpgradeWeaponShouldIncreaseDestructionLevel()
            {
                Weapon weapon = new Weapon("pushka", 12.5, 2);

                Planet planet = new Planet("zemq", 100);
                planet.AddWeapon(weapon);

                int expectedDestructionLevel = weapon.DestructionLevel + 1;

                planet.UpgradeWeapon(weapon.Name);

                Assert.AreEqual(expectedDestructionLevel, weapon.DestructionLevel);
            }

            [Test]
            public void PlanetShouldNotDestroyStrongerOpponent()
            {
                Planet planet = new Planet("zemq", 100);

                Weapon weapon = new Weapon("pistolet", 12.5, 1);
                Weapon weapon1 = new Weapon("pushka", 12.5, 1);
                Weapon weapon2 = new Weapon("avtomat", 12.5, 1);

                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                Planet opponent = new Planet("Mars", 100);

                Weapon opWeapon = new Weapon("pistolet", 12.5, 2);
                Weapon opWeapon1 = new Weapon("pushka", 12.5, 1);
                Weapon opWeapon2 = new Weapon("avtomat", 12.5, 1);

                opponent.AddWeapon(weapon2);
                opponent.AddWeapon(weapon);
                opponent.AddWeapon(weapon1);

                Assert.Throws<InvalidOperationException>((() =>
                {
                    planet.DestructOpponent(opponent);
                }));
            }

            [Test]
            public void PlanetShouldNotDestroyOpponentWithSamePower()
            {
                Planet planet = new Planet("zemq", 100);

                Weapon weapon = new Weapon("pistolet", 12.5, 1);
                Weapon weapon1 = new Weapon("pushka", 12.5, 1);
                Weapon weapon2 = new Weapon("avtomat", 12.5, 1);

                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);

                Planet opponent = new Planet("Mars", 100);

                Weapon opWeapon = new Weapon("pistolet", 12.5, 1);
                Weapon opWeapon1 = new Weapon("pushka", 12.5, 1);
                Weapon opWeapon2 = new Weapon("avtomat", 12.5, 1);

                opponent.AddWeapon(weapon2);
                opponent.AddWeapon(weapon);
                opponent.AddWeapon(weapon1);

                Assert.Throws<InvalidOperationException>((() =>
                {
                    planet.DestructOpponent(opponent);
                }));
            }

            [Test]
            public void PlanetDestructOpponentShouldReturnAProperString()
            {

                Planet planet = new Planet("zemq", 100);

                Weapon weapon = new Weapon("pistolet", 12.5, 100);
                planet.AddWeapon(weapon);

                Planet opponent = new Planet("Mars", 100);

                Weapon opWeapon = new Weapon("pistolet", 12.5, 1);
                opponent.AddWeapon(opWeapon);

                string expectedOutput = $"{opponent.Name} is destructed!";

                Assert.AreEqual(expectedOutput,planet.DestructOpponent(opponent));
            }
        }
    }
}
