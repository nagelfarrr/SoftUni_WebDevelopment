namespace Robots.Tests
{
    using System;
    using System.Runtime.CompilerServices;
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        private Robot testRobot;
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            testRobot = new Robot("Wall-E", 100);
            robotManager = new RobotManager(3);
        }

        [Test]
        public void Robot_ConstructorShouldInitializeProperly()
        {
            string robotName = "Robokop";
            int robotMaximumBattery = 100;

            Robot robot = new Robot(robotName, robotMaximumBattery);

            Assert.AreEqual(robotName, robot.Name);
            Assert.AreEqual(robotMaximumBattery,robot.MaximumBattery);

        }

        [Test]
        public void Robot_BatteryShouldBeSetToToMaximumBatteryAtInitializing()
        {
            int maximumBattery = 100;

            Robot robot = new Robot("Terminator", maximumBattery);

            Assert.AreEqual(maximumBattery,robot.Battery);
        }

        [Test]
        public void RobotManager_ConstructorShouldInitializeProperly()
        {
            int capacity = 5;

            RobotManager manager = new RobotManager(capacity);

            Assert.AreEqual(capacity, manager.Capacity);
        }

        [Test]
        public void RobotManager_CapacityCannotBeNegativeNumber()
        {
            int capacity = -1;

            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager manager = new RobotManager(capacity);
            });
        }

        [Test]
        public void RobotManager_CountShouldIncreaseUponAddingARobot()
        {
            int expectedCount = 1;

            robotManager.Add(testRobot);


            Assert.AreEqual(expectedCount, robotManager.Count);
        }

        [Test]
        public void RobotManager_CannotAddSameRobot()
        {
            robotManager.Add(testRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(testRobot);
            });
        }

        [Test]
        public void RobotManager_CannotAddIfNoCapacity()
        {
            robotManager.Add(testRobot);
            robotManager.Add(new Robot("robokop",100));
            robotManager.Add(new Robot("terminator",100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(new Robot("tenekieniq chovek", 100));
            });
        }

        [Test]
        public void RobotManager_CannotRemoveNonExistingRobot()
        {
            Robot robot = new Robot("Ivan", 100);

            robotManager.Add(testRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove(robot.Name);
            });
        }

        [Test]
        public void RobotManager_ShouldDecreaseCountUponRemovingARobot()
        {
            Robot robotToRemove = new Robot("removedRobot", 100);

            robotManager.Add(testRobot);
            robotManager.Add(robotToRemove);

            robotManager.Remove(robotToRemove.Name);

            Assert.AreEqual(1,robotManager.Count);
        }

        [Test]
        public void RobotManager_RobotCannotWorkIfItsNotInTheManager()
        {
            robotManager.Add(testRobot);

            Robot nonWorkingRobot = new Robot("lazy", 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(nonWorkingRobot.Name, "clean", 100);
            });
        }

        [Test]
        public void RobotManger_RobbotCannotWorkIfNotEnoughBattery()
        {
            int batteryUsage = 200;

            robotManager.Add(testRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(testRobot.Name, "clean", batteryUsage);
            });
        }

        [Test]
        public void RobotManager_RobotBatteryShouldDecreaseAfterWork()
        {
            int batteryUsage = 55;

            int expectedBattery = testRobot.Battery - batteryUsage;

            robotManager.Add(testRobot);
            robotManager.Work(testRobot.Name,"da nacepi darva",batteryUsage);

            Assert.AreEqual(expectedBattery,testRobot.Battery);
        }

        [Test]
        public void RobotManager_CannotChargeNonExistingRobot()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge(testRobot.Name);
            });
        }

        [Test]
        public void RobotManager_BatteryShouldBeSetToMaximumAfterCharge()
        {
            int batteryUsage = 32;
            int expectedBattery = testRobot.MaximumBattery;

            robotManager.Add(testRobot);
            robotManager.Work(testRobot.Name,"izhvarli bokluka", batteryUsage);
            robotManager.Charge(testRobot.Name);


            Assert.AreEqual(expectedBattery,testRobot.Battery);
        }
    }
}
