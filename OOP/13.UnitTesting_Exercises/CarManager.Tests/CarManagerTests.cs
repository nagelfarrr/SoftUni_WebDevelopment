namespace CarManager.Tests
{
    using System;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private const string DefaultMake = "VW";
        private const string DefaultModel = "Golf";
        private const double DefaultFuelConsumption = 2.5;
        private const double DefaultFuelCapacity = 100000.0;
        private Car defaultCar;

        [SetUp]
        public void SetUp()
        {
            defaultCar = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity);
        }

        [Test]
        public void ConstructorShouldInitializeCarMake()
        {
            
            Car car = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity);

            Assert.AreEqual(DefaultMake,car.Make);
        }

        [Test]
        public void ConstructorShouldInitializeCarModel()
        {
         

            Car car = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity);

            Assert.AreEqual(DefaultModel, car.Model);
        }
        [Test]
        public void ConstructorShouldInitializeCarFuelConsumption()
        {


            Car car = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity);

            Assert.AreEqual(DefaultFuelConsumption, car.FuelConsumption);
        }

        [Test]
        public void ConstructorShouldInitializeCarFuelCapacity()
        {


            Car car = new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity);
            
            Assert.AreEqual(DefaultFuelCapacity, car.FuelCapacity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarMakeShouldThrowExceptionIfNullOrEmpty(string make)
        {

            Assert.Throws<ArgumentException>((() =>
                new Car(make, DefaultModel, DefaultFuelConsumption, DefaultFuelCapacity)));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarModelShouldThrowExceptionIfNullOrEmpty(string model)
        {

            Assert.Throws<ArgumentException>((() =>
                new Car(DefaultMake, model, DefaultFuelConsumption, DefaultFuelCapacity)));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-213)]
        public void CarFuelConsumptionShouldThrowExceptionIfZeroOrBelow(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>((() =>
                new Car(DefaultMake, DefaultModel, fuelConsumption, DefaultFuelCapacity)));
        }

        [TestCase(-1)]
        [TestCase(-12312)]
        [TestCase(-0.5)]
        public void CarFuelAmountShouldThrowExceptionIfBelowZero(double fuelAmount)
        {
            
            Assert.Throws<ArgumentException>(() =>
            {
                defaultCar.Refuel(fuelAmount);
            });
        }

       
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-21321)]
        public void CarFuelCapacityShouldThrowExceptionIfZerOrOrBelow(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
                new Car(DefaultMake, DefaultModel, DefaultFuelConsumption, fuelCapacity));
        }

        [TestCase(1)]
        [TestCase(12.6)]
        [TestCase(213.21)]
        public void CarRefuelShouldIncreaseFuelAmount(double fuelToRefuel)
        {
            defaultCar.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelToRefuel,defaultCar.FuelAmount);
        }

        [TestCase(100000.1)]
        [TestCase(212167312.21)]
        public void CarRefuelShouldEqualFuelAmountWhenCapacityIsLessThanFuelAmount(double fuelToRefuel)
        {
            defaultCar.Refuel(fuelToRefuel);

            Assert.AreEqual(defaultCar.FuelCapacity,defaultCar.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-0.5)]
        [TestCase(-1287312)]
        [TestCase(-12.4)]
        public void CarRefuelShouldThrowExceptionWhenRefuelinFuelIsZeroOrBelow(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>((() => defaultCar.Refuel(fuelToRefuel)));
        }

        [Test]
        public void CarDriveShouldThrowExceptionWhenFuelAmountIsLessThanNeededFuel()
        {
            Car car = new Car("Merdjam", "S klasa", 15.8, 92.0);

            Assert.Throws<InvalidOperationException>(() => car.Drive(20));
        }
        [TestCase(1)]
        [TestCase(24.5)]
        [TestCase(31.375)]
        public void CarDecreaseFuelAmountWhenDriving(double distance)
        {
            Car car = new Car("Merdjam", "S klasa", 15.8, 92.0);
            car.Refuel(50);

            double expectedFuelAmount = car.FuelAmount - ((distance / 100) * car.FuelConsumption);
            
            car.Drive(distance);

            Assert.AreEqual(expectedFuelAmount,car.FuelAmount);
        }

    }
}