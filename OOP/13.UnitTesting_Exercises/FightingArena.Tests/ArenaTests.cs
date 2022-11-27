namespace FightingArena.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void ArenaCountShouldBeEqualToWarriorsCollection()
        {
            Warrior warrior = new Warrior("Ivan", 45, 50);
            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);
        }
        [Test]
        public void ArenaCollectionShouldReturnWarriorsCollection()
        {
            Warrior warrior = new Warrior("Ivan", 45, 50);
            List<Warrior> warriors = new List<Warrior>() { warrior };
            arena.Enroll(warrior);

            CollectionAssert.AreEqual(warriors, arena.Warriors);
        }

        [Test]
        public void ArenaEnrollShouldThrowExceptionWhenWarriorsWithSameNameAreAdded()
        {
            Warrior w1 = new Warrior("Ivan", 45, 50);
            Warrior w2 = new Warrior("Ivan", 50, 100);

            arena.Enroll(w1);

            Assert.Throws<InvalidOperationException>((() => arena.Enroll(w2)), "Cannot add warriors with same name");
        }

        [Test]
        public void ArenaShouldNotEnrollSameWarriorTwice()
        {
            Warrior warrior = new Warrior("Iavn", 50, 60);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>((() => arena.Enroll(warrior)), "Cannot add warriors with same name");
        }

        [Test]
        public void ArenaEnrollShouldAddWarriorToTheCollection()
        {
            Warrior w1 = new Warrior("Ivan", 45, 50);
            Warrior w2 = new Warrior("Toshko", 50, 100);

            List<Warrior> warriors = new List<Warrior>() { w1,w2 };

            arena.Enroll(w1);
            arena.Enroll(w2);

            CollectionAssert.AreEqual(warriors,arena.Warriors);
        }

        [Test]
        public void FightShouldNotStartWhenAttackerNameDoesNotExist()
        {
            Warrior w1 = new Warrior("Ivan", 45, 50);
            Warrior w2 = new Warrior("Toshko", 50, 100);
            arena.Enroll(w1);
            arena.Enroll(w2);

            Assert.Throws<InvalidOperationException>((() => arena.Fight("Petar", w2.Name)));
        }

        [Test]
        public void FightShouldNotStartWhenDefenderNameDoesNotExist()
        {
            Warrior w1 = new Warrior("Ivan", 45, 50);
            Warrior w2 = new Warrior("Toshko", 50, 100);
            arena.Enroll(w1);
            arena.Enroll(w2);

            Assert.Throws<InvalidOperationException>((() => arena.Fight(w1.Name, "Petar")));
        }

        [Test]
        public void AttackerShouldAttackDefender()
        {
            Warrior attacker = new Warrior("Ivan", 50, 100);
            Warrior defender = new Warrior("Toshko", 50, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            int expectedAttackerHp = attacker.HP - defender.Damage;
            int expectedDefenderHp = defender.HP - attacker.Damage;

            arena.Fight(attacker.Name,defender.Name);

            Assert.IsTrue(attacker.HP == expectedAttackerHp && defender.HP == expectedDefenderHp);
        }
    }
}
