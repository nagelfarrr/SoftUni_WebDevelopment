using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    using System;

    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartPhone;
        private Shop testShop;

        [SetUp]
        public void SetUp()
        {
            smartPhone = new Smartphone("Samsung", 100);
            testShop = new Shop(3);
            

        }


        [Test]
        public void Smarthphone_ModelNameProperyShouldBeSetFromConstructor()
        {
            string phoneModel = "Nokia";
            Smartphone phone = new Smartphone(phoneModel, 100);

            Assert.AreEqual(phoneModel,phone.ModelName);
        }

        [Test]
        public void Smarthphone_MaximumBatteryChargeProperyShouldBeSetFromConstructor()
        {
            int phoneMaximumCharge = 100;

            Smartphone phone = new Smartphone("Motorola", phoneMaximumCharge);

            Assert.AreEqual(phoneMaximumCharge,phone.MaximumBatteryCharge);
        }

        [Test]
        public void Smarthphone_CurrentBatteryShouldBeSameAsMaximumBatteryWhenInitialized()
        {
            Assert.AreEqual(smartPhone.MaximumBatteryCharge,smartPhone.CurrentBateryCharge);
        }

        [Test]
        public void Shop_ConstructorShouldSetCapacity()
        {
            int shopCapacity = 10;

            Shop shop = new Shop(shopCapacity);

            Assert.AreEqual(shopCapacity,shop.Capacity);
        }

        [TestCase(-1)]
        [TestCase(-1000)]
        public void Shop_CapacityCannotBeLessThanZero(int negativeCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(negativeCapacity);
            });
        }

        [Test]
        public void Shop_CannotAddSamePhoneModelMoreThanOnce()
        {
            testShop.Add(smartPhone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testShop.Add(smartPhone);
            });
        }

        [Test]
        public void Shop_CannotAddPhonesWhenCapacityIsEqualToPhonesCollection()
        {
            Smartphone phone = new Smartphone("Nokia", 100);
            Smartphone phone2 = new Smartphone("Motorola", 100);
            Smartphone phoneCannotBeAdded = new Smartphone("Apple", 100);

            testShop.Add(smartPhone);
            testShop.Add(phone);
            testShop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testShop.Add(phoneCannotBeAdded);
            });
        }

        [Test]
        public void Shop_CountShouldIncrementWhenPhoneIsAdded()
        {
            testShop.Add(smartPhone);

            Assert.AreEqual(1,testShop.Count);
        }

        [Test]
        public void Shop_CountShouldDecrementWhenPhoneIsRemoved()
        {
            testShop.Add(smartPhone);

            testShop.Remove("Samsung");

            Assert.AreEqual(0,testShop.Count);
        }

        [Test]
        public void Shop_CannotRemovePhoneThatIsNotInTheShop()
        {
            testShop.Add(smartPhone);

            Assert.Throws<InvalidOperationException>((() =>
            {
                testShop.Remove("Nokia");
            }));
        }


        [Test]
        public void Shop_CannotTestPhoneThatIsNotInTheShop()
        {
            testShop.Add(smartPhone);

            Assert.Throws<InvalidOperationException>((() =>
            {
                testShop.TestPhone("Nokia",100);
            }));
        }


        [Test]
        public void Shop_CannotTestPhoneThatHasLowBattery()
        {
            testShop.Add(smartPhone);

            Assert.Throws<InvalidOperationException>((() =>
            {
                testShop.TestPhone("Samsung",101);
            }));
        }

        [Test]
        public void Shop_SmartphoneCurrentBatteryShouldDecreaseByNeededBatteryUsage()
        {
            int batteryUsage = 50;

            int expectedCyrrentBattery = smartPhone.CurrentBateryCharge - batteryUsage;

            testShop.Add(smartPhone);

            testShop.TestPhone("Samsung",batteryUsage);

            Assert.AreEqual(expectedCyrrentBattery,smartPhone.CurrentBateryCharge);
        }

        [Test]
        public void Shop_CannotChargePhoneThatIsNotInTheShop()
        {
            testShop.Add(smartPhone);

            Assert.Throws<InvalidOperationException>((() =>
            {
                testShop.ChargePhone("Nokia");
            }));
        }

        [Test]
        public void Shop_PhoneCurrentBatteryShouldBeSetToMaximumWhenCharged()
        {
            int maximumBattery = 80;

            Smartphone phone = new Smartphone("Nokia", 80);

            testShop.Add(phone);

            testShop.TestPhone("Nokia",30);

            testShop.ChargePhone("Nokia");

            Assert.AreEqual(maximumBattery,phone.CurrentBateryCharge);
        }
    }
}