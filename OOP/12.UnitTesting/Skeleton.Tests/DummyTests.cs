using NUnit.Framework;

namespace Skeleton.Tests
{
    using System;

    [TestFixture]
    public class DummyTests
    {
        private Dummy deadDummy;
        private Dummy aliveDummy;

        [SetUp]
        public void SetUp()
        {
            deadDummy = new Dummy(0, 0);
            aliveDummy = new Dummy(1, 1);
        }

        [Test]
        public void Test_DummyShouldLoseHealthIfAttacked()
        {
            aliveDummy = new Dummy(10, 1);
            aliveDummy.TakeAttack(1);

            Assert.AreEqual(9,aliveDummy.Health);
        }

        [Test]
        public void Test_DummyShouldThrowExceptionIfAttackedWhileDead()
        {
            
            Assert.Throws<InvalidOperationException>(() => deadDummy.TakeAttack(10), "asd");
        }

        [Test]
        public void Test_DummyShouldGiveXPIfDead()
        {
            deadDummy = new Dummy(0, 5);

            Assert.AreEqual(5,deadDummy.GiveExperience());
        }

        [Test]
        public void Test_AliveDummyShouldNOTGiveXP()
        {
            Assert.Throws<InvalidOperationException>(() => aliveDummy.GiveExperience(), "Target is not dead.");
        }
    }
}