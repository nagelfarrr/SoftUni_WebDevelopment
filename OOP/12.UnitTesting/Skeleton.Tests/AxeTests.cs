using NUnit.Framework;

namespace Skeleton.Tests
{
    using System;

    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test_AxeConstructor()
        {
            Axe axe = new Axe(10, 10);
            Assert.AreEqual(10,axe.AttackPoints);
            Assert.AreEqual(10,axe.DurabilityPoints);
        }

        [Test]
        public void Test_AxeConstructorWithNegativeIntegers()
        {
            Axe axe = new Axe(-2, 2);
            Assert.AreEqual(-2,axe.AttackPoints);

            Axe axe2 = new Axe(2, -2);
            Assert.AreEqual(-2, axe2.DurabilityPoints);

            Axe axe3 = new Axe(0,0); 
            Assert.AreEqual(0,axe3.DurabilityPoints);
            Assert.AreEqual(0,axe3.AttackPoints);
        }

        [Test]
        public void AxeShouldLoseDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesn't change after attack.");
        }

        [Test]
        public void Test_BrokenAxeShouldThrowException()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 0);

            
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken.");
        }
    }
}