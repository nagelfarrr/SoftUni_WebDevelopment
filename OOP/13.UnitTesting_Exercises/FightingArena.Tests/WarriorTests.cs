namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior validWarrior;
        private Warrior validEnemy;

        [SetUp]
        public void SetUp()
        {
            validWarrior = new Warrior("Ivan", 45, 100);
            validEnemy = new Warrior("Toshko", 50, 95);
        }

        [Test]
        public void ConstructorShouldInitializeProperly()
        {

            Assert.AreEqual("Ivan", validWarrior.Name);
            Assert.AreEqual(45, validWarrior.Damage);
            Assert.AreEqual(100, validWarrior.HP);

        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("            ")]
        [TestCase(null)]
        public void WarriorNameShouldThrowExceptionWhenNullOrWhiteSpace(string name)
        {
            
            Assert.Throws<ArgumentException>((() => new Warrior(name,45,100)), "Name should not be empty or whitespace!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void WarriorDamageShouldThrowExceptionWhenZeroOrBelow(int damage)
        {
            Assert.Throws<ArgumentException>((() => new Warrior("Ivan", damage, 100)),
                "Damage value should be positive!");
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void WarriorHpShouldThrowExceptionWhenBelowZero(int hp)
        {
            Assert.Throws<ArgumentException>((() => new Warrior("Ivan", 45, hp)),
                "HP value should be positive!");
        }


        [TestCase(30)]
        [TestCase(29)]
        [TestCase(1)]
        public void WarriorShouldNotAttackIfHpIsEqualOrBelow30(int hp)
        {
            Warrior warrior = new Warrior("Ivan", 50, hp);

            Assert.Throws<InvalidOperationException>((() => warrior.Attack(validEnemy)),
                "Warrior cannot attack if his HP is below 30");
        }

        [TestCase(30)]
        [TestCase(29)]
        [TestCase(1)]
        public void WarriorShouldNotAttackIfEnemyHpIsEqualOrBelow30(int hp)
        {
            Warrior enemy = new Warrior("Ivan", 50, hp);

            Assert.Throws<InvalidOperationException>((() => validWarrior.Attack(enemy)),
                "Warrior cannot attack Warriors whose HP are below 30");
        }

        [Test]
        public void WarriorShouldNotAttackStrongerEnemies()  //stronger enemy is considered when warrior has less hp than enemy damage
        {
            Warrior weakWarrior = new Warrior("Ivan", 45, 35);
            Warrior strongEnemy = new Warrior("Toshko", 45, 100);

            Assert.Throws<InvalidOperationException>((() => weakWarrior.Attack(strongEnemy)),
                "Warrior cannot attack stronger enemies");
        }

        [Test]
        public void WarriorHpShouldDecreaseAfterAttack()
        {
            int expectedHp = validWarrior.HP - validEnemy.Damage;
            validWarrior.Attack(validEnemy);


            Assert.AreEqual(expectedHp,validWarrior.HP);
        }

        [TestCase(99)]
        [TestCase(50)]
        public void EnemyHpShouldEqualsZeroWhenWarriorDamageGreaterThanEnemyHp(int hp)
        {
            Warrior warrior = new Warrior("Ivan", 100, 100);
            Warrior enemy = new Warrior("Toshko", 100, hp);

            warrior.Attack(enemy);
            Assert.AreEqual(0,enemy.HP);
        }

        [Test]
        public void EnemyHpShouldDecreaseWhenWarriorDamageAttacked()
        {
            Warrior warrior = new Warrior("Ivan", 50, 100);
            Warrior enemy = new Warrior("Toshko", 100, 100);

            int expectedEnemyHp = enemy.HP - warrior.Damage;

            warrior.Attack(enemy);

           Assert.AreEqual(expectedEnemyHp,enemy.HP);
        }
    }
}