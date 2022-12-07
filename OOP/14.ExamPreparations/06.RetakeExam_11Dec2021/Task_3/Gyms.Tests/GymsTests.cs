namespace Gyms.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class GymsTests
    {
        private Athlete athlete;
        private Gym testGym;

        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete("Petkan");
            testGym = new Gym("Sportna Zala", 3);
        }

        [Test]
        public void Athlete_NameShouldBeInitializedFromConstructor()
        {
            string expectedName = "Ivan";

            Athlete athl = new Athlete(expectedName);

            Assert.AreEqual(expectedName, athl.FullName);
        }

        [Test]
        public void Athlete_ShouldBeNotInjuredByDefault()
        {
            Assert.IsFalse(athlete.IsInjured);
        }

        [Test]
        public void Gym_NameShouldBeInitializedFromConstructor()
        {
            string gymName = "sportna zala";

            Gym gym = new Gym(gymName, 2);

            Assert.AreEqual(gymName, gym.Name);
        }

        [Test]
        public void Gym_CapacityShouldBeInitializedFromConstructor()
        {
            int gymSize = 3;

            Gym gym = new Gym("zala", gymSize);

            Assert.AreEqual(gymSize, gym.Capacity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Gym_NameCannotBeNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, 2);
            });
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void Gym_CapacityCannotBeBelowNegativeInteger(int size)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("zala", size);
            });
        }

        [Test]
        public void Gym_CountShouldReturnNumberOfAthletesInTheGym()
        {
            Athlete athlete2 = new Athlete("Ivan");
            Athlete athlete3 = new Athlete("Keran");

            testGym.AddAthlete(athlete);
            testGym.AddAthlete(athlete2);
            testGym.AddAthlete(athlete3);

            int expectedCount = 3;

            Assert.AreEqual(expectedCount, testGym.Count);
        }

        [Test]
        public void Gym_CannotAddAthleteWhenCountEqualsCapacity()
        {
            Athlete athlete2 = new Athlete("Ivan");
            Athlete athlete3 = new Athlete("Keran");

            testGym.AddAthlete(athlete);
            testGym.AddAthlete(athlete2);
            testGym.AddAthlete(athlete3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                testGym.AddAthlete(new Athlete("Dragan"));
            });
        }

        [Test]
        public void Gym_ShouldAddAthleteInTheCollection()
        {
            athlete.IsInjured = true;
            
            testGym.AddAthlete(athlete);
            var expectedAthlete = testGym.InjureAthlete("Petkan");

            Assert.AreSame(athlete, expectedAthlete);

        }

        [Test]
        public void Gym_ShouldRemoveProperlyAthlete()
        {
            testGym.AddAthlete(athlete);

            int expectedCountAfterRemoving = 0;

            testGym.RemoveAthlete("Petkan");

            Assert.AreEqual(expectedCountAfterRemoving,testGym.Count);

        }

        [Test]
        public void Gym_ShouldNotRemoveNonExistentAthleteInTheGym()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                testGym.RemoveAthlete("Ivanka");
            });
        }

        [Test]
        public void Gym_ShoudSetAthleteToInjured()
        {
            testGym.AddAthlete(athlete);
            testGym.InjureAthlete("Petkan");
            
            Assert.IsTrue(athlete.IsInjured);
        }

        [Test]
        public void Gym_CannotInjureNonExistentAthleteInTheGym()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                testGym.InjureAthlete("Stamat");
            });
        }

        [Test]
        public void Gym_ReportShouldReturnNonInjuredAthletesInAString()
        {
            testGym.AddAthlete(athlete);

            string expectedOutput = $"Active athletes at {testGym.Name}: {athlete.FullName}";

            Assert.AreEqual(expectedOutput,testGym.Report());
        }

        [Test]
        public void Gym_ReportShouldReturnMultipleNonInjuredAthletesInAString()
        {
            testGym.AddAthlete(athlete);
            testGym.AddAthlete(new Athlete("Ivan"));
            testGym.AddAthlete(new Athlete("Oleg"));

            testGym.InjureAthlete("Oleg");
            string expectedOutput = $"Active athletes at {testGym.Name}: Petkan, Ivan";

            Assert.AreEqual(expectedOutput, testGym.Report());
        }
    }
}
