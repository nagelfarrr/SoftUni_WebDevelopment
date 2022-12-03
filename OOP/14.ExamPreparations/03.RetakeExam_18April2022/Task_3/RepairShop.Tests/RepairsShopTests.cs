using NUnit.Framework;

namespace RepairShop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tests
    {
        public class RepairsShopTests
        {
            private Car fixedCar;
            private Car brokenCar;
            private Garage garage;

            [SetUp]
            public void SetUp()
            {
                fixedCar = new Car("BMW", 0);
                brokenCar = new Car("Audi", 2);
                garage = new Garage("Bai Ivan", 3);
            }

            [Test]
            public void CarConstructorShouldInitializeProperly()
            {
                string expectedCarModel = "Mercedes";
                int expectedIssues = 1;

                Car car = new Car(expectedCarModel, expectedIssues);

                Assert.AreEqual(expectedCarModel, car.CarModel);
                Assert.AreEqual(expectedIssues, car.NumberOfIssues);
            }

            [Test]
            public void CarShouldBeFixedWhenNoIssues()
            {
                Car car = new Car("Mercedes", 0);

                Assert.IsTrue(car.IsFixed);
            }

            [Test]
            public void CarShouldNotBeFixedWhenIssuesArePresent()
            {
                Car car = new Car("Mercedes", 1);

                Assert.IsFalse(car.IsFixed);
            }

            [Test]
            public void GarageConstructorShouldInitializeProperly()
            {
                string expectedGarageName = "parking";
                int expectedMechanics = 3;

                Garage garage = new Garage(expectedGarageName, expectedMechanics);

                Assert.AreEqual(expectedGarageName, garage.Name);
                Assert.AreEqual(expectedMechanics, garage.MechanicsAvailable);
            }

            [TestCase(null)]
            [TestCase("")]
            public void GarageNameShouldNotBeNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentNullException>((() =>
                {
                    Garage garage = new Garage(name, 1);
                }));
            }

            [TestCase(0)]
            [TestCase(-1)]
            [TestCase(-100)]
            public void GarageMechanicsShouldNotBeZeroOrBelow(int mechanics)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("mola", mechanics);
                });
            }

            [Test]
            public void GarageCarsInShouldReturnCountOfCarCollection()
            {
                List<Car> cars = new List<Car>() { fixedCar, brokenCar };

                for (int i = 0; i < cars.Count; i++)
                {
                    garage.AddCar(cars[i]);
                }

                Assert.AreEqual(cars.Count, garage.CarsInGarage);
            }

            [Test]
            public void GarageShouldNotAddCarWhenNotEnoughMechanics()
            {
                garage.AddCar(brokenCar);
                garage.AddCar(brokenCar);
                garage.AddCar(fixedCar);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(brokenCar);
                });
            }

            [Test]
            public void GarageCannotFixUnexistingCar()
            {
                garage.AddCar(fixedCar);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(brokenCar.CarModel);
                });
            }

            [Test]
            public void GarageFixedCarShouldSetNumberOfIssuesToZero()
            {
                garage.AddCar(brokenCar);

                garage.FixCar(brokenCar.CarModel);

                Assert.AreEqual(0,brokenCar.NumberOfIssues);
            }

            [Test]
            public void GarageCannotRemoveCarsWhenNoFixedCars()
            {
               garage.AddCar(brokenCar);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }

            [Test]
            public void GarageShouldRemoveOnlyFixedCars()
            {
                garage.AddCar(brokenCar);
                garage.AddCar(fixedCar);

                garage.RemoveFixedCar();

                Assert.AreEqual(1,garage.CarsInGarage);
            }


            [Test]
            public void GarageShouldReportOnlyBrokenCars()
            {
                Car brokenCar2 = new Car("Lada", 2);

                garage.AddCar(brokenCar);
                garage.AddCar(fixedCar);
                garage.AddCar(brokenCar2);

                var cars = new List<Car>() { brokenCar, brokenCar2, fixedCar }.Where(c => !c.IsFixed).Select(c=>c.CarModel).ToList();

                string expectedOutput = $"There are {cars.Count} which are not fixed: {string.Join(", ", cars)}.";

                Assert.AreEqual(expectedOutput,garage.Report());

            }
        }
    }
}